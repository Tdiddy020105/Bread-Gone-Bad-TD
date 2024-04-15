using UnityEngine;

public class AttackableStructure : MonoBehaviour
{
    [SerializeField] private int health;

    public bool IsDestroyed()
    {
        return this.GetHealth() <= 0;
    }

    public void TakeDamage(int amount)
    {
        if (this.IsDestroyed())
        {
            return;
        }

        this.health -= amount;

        if (this.health <= 0)
        {
            this.health = 0;
            this.SendMessage("AttackableStructureDestroyed");
        }
    }

    public int GetHealth()
    {
        return this.health;
    }
}
