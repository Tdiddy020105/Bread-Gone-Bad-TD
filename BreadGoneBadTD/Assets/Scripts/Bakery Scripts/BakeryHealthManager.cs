using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class BakeryHealthManager : MonoBehaviour
{

    public Image healthBar;
    //public float healthAmount = 100f;
    public AttackableStructure bakeryStructure;

    // Start is called before the first frame update
    void Start()
    {
        // Find the bakery GameObject in the scene
        GameObject bakeryGameObject = GameObject.Find("Bakery"); // Replace "Bakery" with the name of your bakery GameObject
        if (bakeryGameObject != null)
        {
            // Get the AttackableStructure component attached to the bakery GameObject
            bakeryStructure = bakeryGameObject.GetComponent<AttackableStructure>();
            if (bakeryStructure == null)
            {
                Debug.LogError("Bakery GameObject does not have an AttackableStructure component.");
            }
        }
        else
        {
            Debug.LogError("Bakery GameObject not found in the scene.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Update health bar based on bakery health
        if (bakeryStructure != null)
        {
            healthBar.fillAmount = bakeryStructure.GetHealth() / 100f;
        }
    }

    public void BakeryTakeDamage(float damage)
    {
        if (bakeryStructure != null)
        {
            bakeryStructure.TakeDamage((int)damage);
        }
    }
}

