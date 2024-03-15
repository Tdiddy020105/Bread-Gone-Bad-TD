using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject bakery;
    private Transform healthBar;
    private float life;
    private float maxLife;

    void Start()
    {
        healthBar.transform.Find("BakeryHealthGreen");
        life = 40f;     // remove when Daphne's bakery script is implemented
        // life = bakery.GetComponent<BakeryHealth>.GetHitPoints();           // Daphne implementation
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
         * else if (life != bakery.GetComponent<BakeryHealth>.GetHitPoints() && life > 0)
         * {
         *  life = bakery.GetComponent<BakeryHealth>.GetHitPoints();
         *  healthBar.localScale = new Vector3(life / maxLife, 1f);
         * }
         * 
         * Once Daphne gets health to work for bakery
        */
    }
}
