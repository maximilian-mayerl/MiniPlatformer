using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    [SerializeField] private float moveVelocity = 5f;
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;

    private bool isJumping = false;

    void Start() {
    }

    void Update() {
        // Get inputs.
        float horizontalInput = Input.GetAxis("Horizontal");
        bool doJump = Input.GetButtonDown("Jump");

        // Move character horizontally.
        if (!this.isJumping) {
            this.rigidBody.velocity = new Vector2(this.moveVelocity * horizontalInput, this.rigidBody.velocity.y);

            // Set orientation.
            if (horizontalInput != 0) {
                this.transform.localScale = new Vector3(horizontalInput < 0 ? -Mathf.Abs(this.transform.localScale.x) : Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
        }

        // Jumping.
        if (doJump && !this.isJumping) {
            this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, this.jumpVelocity);
            this.isJumping = true;
            this.animator.SetBool("IsJumping", true);
        }

        // Give the speed to the animator.
        this.animator.SetFloat("HorizontalSpeed", Mathf.Abs(this.rigidBody.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Reset jumping ability when we touch firm ground again.
        if (collision.gameObject.tag == "Terrain") {
            this.isJumping = false;
            this.animator.SetBool("IsJumping", false);
        }
    }
}
