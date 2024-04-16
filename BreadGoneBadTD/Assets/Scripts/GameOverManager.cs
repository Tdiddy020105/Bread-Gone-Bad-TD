using DesignPatterns.EnemyPool;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private WaveManager waveManager = null;
    private static GameOverState gameOverState = null;

    private void Start()
    {
        // Retrieve the wave manager when no game over state has been set
        if (gameOverState == null)
        {
            this.waveManager = GameObject.Find("WaveManager")?.GetComponent<WaveManager>();

            if (this.waveManager == null)
            {
                throw new System.Exception("Game over manager broken, can't find \"WaveManager\" game object.");
            }

            return;
        }

        // Update game over menu and reset game over state
        GameOverMenu gameOverMenu = this.GetComponent<GameOverMenu>();

        if (gameOverMenu == null)
        {
            throw new System.Exception("Game over manager broken, can't find \"GameOverMenu\" script.");
        }

        int receivedCurrency = gameOverState.wave;

        gameOverMenu.UpdateWaveNumber(gameOverState.wave);
        gameOverMenu.UpdateReceivedPermanentCurrency(receivedCurrency);

        CurrencyManager.Instance.Earn(receivedCurrency, CurrencyType.PERMANENT);

        gameOverState = null;
    }

    public void AttackableStructureDestroyed()
    {
        gameOverState = new GameOverState(this.waveManager.GetWaveNumber());
        SceneManager.LoadScene("GameOver");
    }
}

public class GameOverState
{
    public int wave;

    public GameOverState() {}
    public GameOverState(int wave)
    {
        this.wave = wave;
    }
}
