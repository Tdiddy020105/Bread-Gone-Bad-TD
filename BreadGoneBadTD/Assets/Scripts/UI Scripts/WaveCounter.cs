using DesignPatterns.EnemyPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] WaveManager waveManager;
    [SerializeField] TextMeshProUGUI waveCounter;

    void Update()
    {
        waveCounter.text = waveManager.GetWaveNumber().ToString();
    }
}
