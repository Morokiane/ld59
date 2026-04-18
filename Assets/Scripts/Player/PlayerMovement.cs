using System;
using Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Vector2 moveInput;

        private Rigidbody2D rb;
        private Animator anim;
        private BoxCollider2D boxCollider2D;
        private SpriteRenderer spriteRenderer;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update() {
            HandleAnimation();
        }
        private void FixedUpdate() {
            rb.linearVelocity = moveInput * moveSpeed;
        }

        public void Move(InputAction.CallbackContext context) {
            moveInput = context.ReadValue<Vector2>();
        }

        private void HandleAnimation() {
            bool isMoving = moveInput != Vector2.zero;

            anim.SetBool("isWalking", isMoving);

            if (moveInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (moveInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
    }
}
