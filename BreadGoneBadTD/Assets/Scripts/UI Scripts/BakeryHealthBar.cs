using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakeryHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject bakery;
    [SerializeField] private Image healthBar;
    private float life;
    private float maxLife;

    void Start()
    {
        life = 40f;
        // life = bakery.GetComponent<AttackableStructure>().GetHealth();
        maxLife = life;
    }

    void Update()
    {
        if (life <= 0)
        {
            life = 0;
            healthBar.fillAmount = life / maxLife;
        }
        /*
        else if (life != bakery.GetComponent<AttackableStructure>().GetHealth() && life > 0)
        {
            life = bakery.GetComponent<AttackableStructure>().GetHealth();
            healthBar.fillAmount = life / maxLife;
        }
        */
    }
}
