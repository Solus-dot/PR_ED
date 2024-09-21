using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor.UIElements;

public class TitleScreenManager : MonoBehaviour {
    public static TitleScreenManager instance;

    [Header("Menus")]
    [SerializeField] GameObject titleScreenMainMenu;
    [SerializeField] GameObject titleScreenLoadMenu;

    [Header("Buttons")]
    [SerializeField] Button mainMenuNewGameButton;
    [SerializeField] Button loadMenuReturnButton;
    [SerializeField] Button mainMenuLoadGameButton;
    [SerializeField] Button deleteCharacterPopUpConfirmButton;

    [Header("Pop Ups")]
    [SerializeField] GameObject noCharacterSlotsPopUp;
    [SerializeField] Button noCharacterSlotsOkayButton;
    [SerializeField] GameObject deleteCharacterSlotPopUp;

    [Header("Character Save Slots")]
    public CharacterSlot currentSelectedSlot = CharacterSlot.NO_SLOT;

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

    // Character Slots

    public void SelectCharacterSlot(CharacterSlot characterSlot) {
        currentSelectedSlot = characterSlot;
    }

    public void SelectNoSlot() {
        currentSelectedSlot = CharacterSlot.NO_SLOT;
    }

    public void AttemptToDeleteCharacterSlot() {
        if (currentSelectedSlot != CharacterSlot.NO_SLOT) {
            deleteCharacterSlotPopUp.SetActive(true);
            deleteCharacterPopUpConfirmButton.Select();
        }
    }

    public void DeleteCharacterSlot() {
        deleteCharacterSlotPopUp.SetActive(false);
        SaveGameManager.instance.DeleteGame(currentSelectedSlot);
        titleScreenLoadMenu.SetActive(false);
        titleScreenLoadMenu.SetActive(true);
        loadMenuReturnButton.Select();
    }

    public void CloseDeleteCharacterPopUp() {
        deleteCharacterSlotPopUp.SetActive(false);
        loadMenuReturnButton.Select();
    }
}
