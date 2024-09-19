using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour {
    public static TitleScreenManager instance;

    [Header("Menus")]
    [SerializeField] GameObject titleScreenMainMenu;
    [SerializeField] GameObject titleScreenLoadMenu;

    [Header("Buttons")]
    [SerializeField] Button mainMenuNewGameButton;
    [SerializeField] Button loadMenuReturnButton;
    [SerializeField] Button mainMenuLoadGameButton;

    [Header("Pop Ups")]
    [SerializeField] GameObject noCharacterSlotsPopUp;
    [SerializeField] Button noCharacterSlotsOkayButton;

    [Header("Character Save Slots")]
    public CharacterSlot currentCharacterSlot;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void StartNetworkAsHost()  {
        NetworkManager.Singleton.StartHost();
    }

    public void StartNewGame()  {
        SaveGameManager.instance.AttemptToCreateNewGame();
    }

    public void OpenLoadGameMenu() {
        titleScreenMainMenu.SetActive(false);
        titleScreenLoadMenu.SetActive(true);
        loadMenuReturnButton.Select();
    }

    public void CloseLoadGameMenu() {
        titleScreenMainMenu.SetActive(true);
        titleScreenLoadMenu.SetActive(false);
        mainMenuLoadGameButton.Select();
    }

    public void DisplayNoFreeSlotsPopUp() {
        noCharacterSlotsPopUp.SetActive(true);
        noCharacterSlotsOkayButton.Select();
    }

    public void CloseNoFreeSlotsPopUp() {
        noCharacterSlotsPopUp.SetActive(false);
        mainMenuNewGameButton.Select();
    }
}
