    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;


    public class InputSystem : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float moveSpeed;
        public Animator animator;
        private Vector2 _moveDirection;

        public InputActionReference move;

        private void Update()
        {
            _moveDirection = move.action.ReadValue<Vector2>();

            // Set animator parameters for animation
            animator.SetFloat("Horizontal", _moveDirection.x);
            animator.SetFloat("Vertical", _moveDirection.y);
            animator.SetFloat("Speed", _moveDirection.magnitude); // Use magnitude instead of sqrMagnitude

            // Set animator parameters for last move direction
            if (_moveDirection != Vector2.zero)
            {
                animator.SetFloat("LastMoveX", _moveDirection.x);
                animator.SetFloat("LastMoveY", _moveDirection.y);
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = _moveDirection * moveSpeed;
        }
    }
