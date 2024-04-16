using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNumber;
    [SerializeField] private TextMeshProUGUI permanentCurrencyReceivedNumber;

    private void Start()
    {
        this.waveNumber.text = "0";
        this.permanentCurrencyReceivedNumber.text = "+0";
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateWaveNumber(int number)
    {
        this.waveNumber.text = number.ToString();
    }

    public void UpdateReceivedPermanentCurrency(int receivedCurrencyAmount)
    {
        this.permanentCurrencyReceivedNumber.text = $"+{receivedCurrencyAmount}";
    }
}
