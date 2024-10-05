using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotionManager : MonoBehaviour {
    CharacterManager character;
    
    [Header("Ground & Jumping")]
    [SerializeField] protected float gravityForce = -20f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckSphereRadius = 0.3f;
    [SerializeField] protected Vector3 yVelocity; // Force at which our character is pulled up or down
    [SerializeField] protected float groundedYVelocity = -20; // Force at which our character is sticking to ground while grounded
    [SerializeField] protected float fallStartYVelocity = -5; // Force at which our character begins to fall when they are not grounded
    protected bool fallingVelocityHasBeenSet = false;
    protected float inAirTimer = 0;

    protected virtual void Awake() {
        character = GetComponent<CharacterManager>();
    }

    protected virtual void Update() {
        HandleGroundCheck();

        if (character.isGrounded) {
            if (yVelocity.y < 0) {
                inAirTimer = 0;
                fallingVelocityHasBeenSet = false;
                yVelocity.y = groundedYVelocity;
            }
        } else {
            if (!character.isJumping && !fallingVelocityHasBeenSet) {
                fallingVelocityHasBeenSet = true;
                yVelocity.y = fallStartYVelocity;
            }

            inAirTimer += Time.deltaTime;
            character.animator.SetFloat("InAirTimer", inAirTimer);
            yVelocity.y += gravityForce * Time.deltaTime;
        }

        character.characterController.Move(yVelocity * Time.deltaTime);
    }

    protected void HandleGroundCheck() {
        character.isGrounded = Physics.CheckSphere(character.transform.position, groundCheckSphereRadius, groundLayer);
    }

    protected void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(character.transform.position, groundCheckSphereRadius);
    }
}
