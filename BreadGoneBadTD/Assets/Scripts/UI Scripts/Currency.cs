using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    void Start()
    {
        textMeshPro.text = CurrencyManager.Instance.GetCurrencyAmount().ToString();
    }

    private void Update()
    {
        textMeshPro.text = CurrencyManager.Instance.GetCurrencyAmount().ToString();
    }
}