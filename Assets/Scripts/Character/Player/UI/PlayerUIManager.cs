using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerUIManager : MonoBehaviour {
    public static PlayerUIManager instance;
    [HideInInspector] public PlayerUIHUDManager playerUIHUDManager;

    [Header("NETWORK JOIN")]
    [SerializeField] bool startGameAsClient;

     private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        playerUIHUDManager = GetComponentInChildren<PlayerUIHUDManager>();
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (startGameAsClient) {
            startGameAsClient = false;

            // Shutdown host to start as a client
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.StartClient();
        }
    }
}
