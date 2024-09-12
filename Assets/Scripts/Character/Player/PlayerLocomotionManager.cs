using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager {
    PlayerManager player;
    public float horizontalMovement;
    public float VerticalMovement;
    public float moveAmount;
    private Vector3 moveDirection;
    [SerializeField] float walkingSpeed;
    [SerializeField] float runningSpeed;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
    }

    public void HandleAllMovement() {

    }

    public void HandleGroundedMovement() {
        moveDirection = PlayerCamera.instance.transform.forward * VerticalMovement;
        moveDirection += PlayerCamera.instance.transform.right * horizontalMovement;
        moveDirection.y = 0;
        moveDirection.Normalize();

        if (PlayerInputManager.instance.moveAmount > 0.5f) {
            // Move at running speed
        } else if (PlayerInputManager.instance.moveAmount <= 0.5f) {
            // Move at walking speed
        }
    }
}
