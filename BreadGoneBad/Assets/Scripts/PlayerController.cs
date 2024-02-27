using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector2 move;


    public void OnMove(InputAction.CallbackContext context){
        move = context.ReadValue<Vector2>(); //Calls the script through the Input system
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
    
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f); //Rotates the player model along with it's movement

        transform.Translate(movement * speed * Time.deltaTime, Space.World); //Calculates the player model's movement speed according to previous variables + time + world space
    }
}
