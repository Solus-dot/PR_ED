using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TitleScreenManager : MonoBehaviour {
    public void StartNetworkAsHost()  {
        NetworkManager.Singleton.StartHost();
    }

    public void StartNewGame()  {
        SaveGameManager.instance.CreateNewGame();
        StartCoroutine(SaveGameManager.instance.LoadWorldScene());
    }
}
