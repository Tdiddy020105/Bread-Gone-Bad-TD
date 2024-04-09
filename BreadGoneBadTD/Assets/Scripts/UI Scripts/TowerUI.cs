using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerUI : MonoBehaviour
{
    [SerializeField] List<TowerData> towers = new List<TowerData>();
    [SerializeField] GameObject TowerUIElementPrefab;
    [SerializeField] GameManager towerUIContent;
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
        GameObject obj = Instantiate(TowerUIElementPrefab, towerUIContent.transform);
        obj.transform.localScale = new Vector3(1f, 1f, 1f);
        TextMeshProUGUI textMeshPro = obj.GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = tower.price.ToString();
        Button button = obj.GetComponentInChildren<Button>();
        button.GetComponent<Image>().sprite = tower.sprite;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { towerPlacer.SelectTower(tower); });
        button.onClick.Invoke();
    }
}