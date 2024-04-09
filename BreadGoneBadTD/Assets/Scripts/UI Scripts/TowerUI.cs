using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerUI : MonoBehaviour
{
    [SerializeField] List<TowerData> towers = new List<TowerData>();
    [SerializeField] GameObject TowerUIElementPrefab;
    [SerializeField] GameObject TowerUIContent;

    void Start()
    {
        foreach(TowerData tower in towers)
        {
            CreateButton(tower);
        }
    }

    void CreateButton(TowerData tower)
    {
        GameObject obj = TowerUIElementPrefab;
        Button button = obj.GetComponentInChildren<Button>();
        TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        // button.onClick.AddListener(// script here to place tower on map);
        //button.GetComponent<Image>().sprite = tower.UIImage;
        //textMeshPro.text = tower.cost.ToString();
        GameObject InstantiatedObj = Instantiate(obj);
        InstantiatedObj.transform.SetParent(TowerUIContent.transform);
        InstantiatedObj.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}