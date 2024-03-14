using UnityEngine;

public class AttackableStructure : MonoBehaviour
{
    [SerializeField] private int health;

    public void DealDamage(int amount)
    {
        if (this.health - amount < 0)
        {
            this.health = 0;
            return;
        }

        this.health -= amount;
    }
}
