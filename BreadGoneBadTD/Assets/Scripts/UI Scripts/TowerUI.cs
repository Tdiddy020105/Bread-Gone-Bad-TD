using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerUI : MonoBehaviour
{
    [SerializeField] List<TowerData> towers = new List<TowerData>();
    [SerializeField] GameObject TowerUIElementPrefab;
    [SerializeField] TowerPlacer towerPlacer;

    void Start()
    {
        foreach (TowerData tower in towers)
        {
            CreateButton(tower);
        }
    }

    void CreateButton(TowerData tower)
    {
        TowerData tempTowerData = tower;
        GameObject obj = TowerUIElementPrefab;
        Button button = obj.GetComponentInChildren<Button>();
        TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = tower.price.ToString();
        GameObject InstantiatedObj = Instantiate(obj);
        InstantiatedObj.transform.SetParent(TowerUIContent.transform);
        InstantiatedObj.transform.localScale = new Vector3(1f, 1f, 1f);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { towerPlacer.SelectTower(tempTowerData); });
        button.GetComponent<Image>().sprite = tower.sprite;
    }
}