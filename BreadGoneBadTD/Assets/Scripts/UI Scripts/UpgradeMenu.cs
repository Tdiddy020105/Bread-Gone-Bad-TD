using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] List<Upgrade<PlayerData>> upgrades;
    [SerializeField] GameObject PermanentUpgradeUIElement;
    [SerializeField] GameObject PermanentUpgradeUIContent;
    [SerializeField] TextMeshProUGUI permanentCurrencyText;

    void Start()
    {
        foreach (Upgrade<PlayerData> upgrade in upgrades)
        {
            CreateButton(upgrade);
        }
        permanentCurrencyText.text = CurrencyManager.Instance.GetCurrencyAmount(CurrencyType.PERMANENT).ToString();
    }

    private void Update()
    {
        permanentCurrencyText.text = CurrencyManager.Instance.GetCurrencyAmount(CurrencyType.PERMANENT).ToString();
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
}
