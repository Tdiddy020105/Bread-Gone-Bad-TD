using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject bakery;
    [SerializeField] private Transform healthBar;
    private float life;
    private float maxLife;

    void Start()
    {
        life = 40f;
        // life = bakery.GetComponent<AttackableStructure>().GetHealth();
        maxLife = life;
        healthBar.localScale = new Vector3(life / maxLife, 1f);
    }

    void Update()
    {
        if (life <= 0)
        {
            life = 0;
            healthBar.localScale = new Vector3(life / maxLife, 1f);
        }
        /*
         * else if (life != bakery.GetComponent<AttackableStructure>().GetHealth() && life > 0)
         * {
         *  life = bakery.GetComponent<AttackableStructure>().GetHealth();
         *  healthBar.localScale = new Vector3(life / maxLife, 1f);
         * }
        */
    }
}
