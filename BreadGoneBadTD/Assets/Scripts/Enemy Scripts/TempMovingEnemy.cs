using UnityEngine;

public class TempMovingEnemy : MonoBehaviour
{
    [SerializeField] private Vector2 move;

    void Update()
    {
        Vector3 newPos = new Vector3(
            this.transform.position.x + this.move.x * Time.deltaTime,
            this.transform.position.y + this.move.y * Time.deltaTime,
            1
        );

        this.transform.position = newPos;
    }
}
