using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Image currencySprite;
    [SerializeField] TextMeshProUGUI currencyText;

    private Color color;

    private bool placementMode;
    private TowerData towerData;

    void Start()
    {
        placementMode = false;
    }

    public void SelectTower(TowerData towerData)
    {
        if (towerData.price <= CurrencyManager.Instance.GetCurrencyAmount())
        {
            placementMode = true;
            this.towerData = towerData;
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    public void PlaceTower(Transform obj)
    {
        if (placementMode)
        {
            towerPrefab.GetComponent<Tower>().SetData(this.towerData);
            placementMode = false;
            Instantiate(towerPrefab, obj.transform, false);
            CurrencyManager.Instance.Spend(this.towerData.price);
        }
    }

    public bool GetPlacementMode()
    {
        return this.placementMode;
    }

    private IEnumerator FlashRed()
    {
        color = currencyText.color;
        currencySprite.color = Color.red;
        currencyText.color = Color.red;
        yield return new WaitForSeconds(1);
        currencySprite.color = Color.white;
        currencyText.color = color;
    }
}