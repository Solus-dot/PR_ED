using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour {
    public static PlayerInputManager instance;
    PlayerControls playerControls;

    [SerializeField] Vector2 movementInput;
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
        instance.enabled = false;
        
        SceneManager.activeSceneChanged += OnSceneChange;
        playerControls = new PlayerControls();
    }

    private void OnSceneChange(Scene oldScene, Scene newScene) {
        // This is for when the player input only works when we are in the World Scene of the game
        if (newScene.buildIndex == SaveGameManager.instance.GetWorldSceneIndex()) {
            instance.enabled = true;
        } else {
            instance.enabled = false;
        }
    }

    private void OnEnable() {
        playerControls.PlayerMovement.Enable();
        playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
    }

    private void OnDisable() {
        playerControls.PlayerMovement.Disable();
    }

    private void OnDestroy() {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void OnApplicationFocus(bool focus) {
        if (enabled) {
            if (focus) playerControls.Enable();
            else playerControls.Disable();
        }
    }

    private void Update() {
        HandleMovementInput();
    }

    private void HandleMovementInput() {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (moveAmount <= 0.5 && moveAmount > 0) moveAmount = 0.5f;
        else if (moveAmount <= 1 && moveAmount > 0.5) moveAmount = 1f;
    }
}
