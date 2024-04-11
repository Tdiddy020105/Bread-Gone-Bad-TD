using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.AI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] List<Upgrade<PlayerData>> upgrades;
    [SerializeField] GameObject PermanentUpgradeUIElement;
    [SerializeField] GameObject PermanentUpgradeUIContent;
    [SerializeField] TextMeshProUGUI permanentCurrencyText;

    void Start()
    {
        this.DisplayUpgrades();
        this.DisplayPermanentCurrency();

        CurrencyManager.Instance.Earn(100, CurrencyType.PERMANENT);
    }

    private void Update()
    {
        this.DisplayPermanentCurrency();
    }

    private void CreateButton(Upgrade<PlayerData> upgrade)
    {
        GameObject obj = Instantiate(PermanentUpgradeUIElement, PermanentUpgradeUIContent.transform);
        obj.transform.localScale = new Vector3(1f, 1f, 1f);
        TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = upgrade.unlockCurrencyAmount.ToString();
        Button button = obj.GetComponentInChildren<Button>();
        button.GetComponent<Image>().sprite = upgrade.UIImage;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { this.GetComponent<PermanentPlayerUpgradesManager>()?.Buy(upgrade, obj); });
        obj.name = upgrade.name;
    }

    private void DisplayUpgrades()
    {
        List<SavePlayerData> boughtUpgrades = PermanentPlayerUpgradesManager.GetAll();

        foreach (Upgrade<PlayerData> upgrade in upgrades)
        {
            if (this.UpgradeHasBeenBought(upgrade, boughtUpgrades))
            {
                continue;
            }

            CreateButton(upgrade);
        }
    }

    private void DisplayPermanentCurrency()
    {
        permanentCurrencyText.text = CurrencyManager.Instance.GetCurrencyAmount(CurrencyType.PERMANENT).ToString();
    }

    private bool UpgradeHasBeenBought(Upgrade<PlayerData> upgrade, List<SavePlayerData> boughtUpgrades)
    {
        bool currentUpgradeHasBeenBought = false;

        foreach (SavePlayerData boughtUpgrade in boughtUpgrades)
        {
            if (boughtUpgrade.name == upgrade.settings.name)
            {
                currentUpgradeHasBeenBought = true;
                break;
            }
        }

        return currentUpgradeHasBeenBought;
    }
}
