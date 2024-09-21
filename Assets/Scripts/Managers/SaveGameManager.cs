using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour {
    public static SaveGameManager instance;

    public PlayerManager player;

    [Header("SAVE/LOAD")]
    [SerializeField] bool saveGame;
    [SerializeField] bool loadGame;
   
    [Header("World Scene Index")]
    [SerializeField] int worldSceneIndex = 1;

    [Header("Save Data Writer")]
    private SaveFileDataWriter saveFileDataWriter;

    [Header("Current Character Data")]
    public CharacterSlot currentCharacterSlotUsed;
    public CharacterSaveData currentCharacterData;
    private string saveFileName;

    [Header("Character Slots")]
    public CharacterSaveData characterSlot01;
    public CharacterSaveData characterSlot02;
    public CharacterSaveData characterSlot03;
    public CharacterSaveData characterSlot04;
    public CharacterSaveData characterSlot05;
    public CharacterSaveData characterSlot06;
    public CharacterSaveData characterSlot07;
    public CharacterSaveData characterSlot08;
    public CharacterSaveData characterSlot09;
    public CharacterSaveData characterSlot10;
   
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
        LoadAllCharacterProfiles();
    }

    private void Update() {
        if (saveGame) {
            saveGame = false;
            SaveGame();
        }

        if (loadGame) {
            loadGame = false;
            LoadGame();
        }
    }

    public string DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot characterSlot) {
        string fileName = "";

        switch (characterSlot) {
            case CharacterSlot.characterSlot_01:
                fileName = "CharacterSlot_01";
                break;
            case CharacterSlot.characterSlot_02:
                fileName = "CharacterSlot_02";
                break;
            case CharacterSlot.characterSlot_03:
                fileName = "CharacterSlot_03";
                break;
            case CharacterSlot.characterSlot_04:
                fileName = "CharacterSlot_04";
                break;
            case CharacterSlot.characterSlot_05:
                fileName = "CharacterSlot_05";
                break;
            case CharacterSlot.characterSlot_06:
                fileName = "CharacterSlot_06";
                break;
            case CharacterSlot.characterSlot_07:
                fileName = "CharacterSlot_07";
                break;
            case CharacterSlot.characterSlot_08:
                fileName = "CharacterSlot_08";
                break;
            case CharacterSlot.characterSlot_09:
                fileName = "CharacterSlot_09";
                break;
            case CharacterSlot.characterSlot_10:
                fileName = "CharacterSlot_10";
                break;
            default:
                break;
        }

        return fileName;
    }

    public void AttemptToCreateNewGame() {
        saveFileDataWriter = new SaveFileDataWriter();
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;

        // Check to see if we can create a new save file
        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_01);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_01;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_02);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_02;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_03);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_03;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_04);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_04;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_05);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_05;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_06);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_06;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_07);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_07;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_08);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_08;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_09);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_09;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_10);
        if (!saveFileDataWriter.CheckIfFileExists()) {
            // If slot not taken, create a new save file.
            currentCharacterSlotUsed = CharacterSlot.characterSlot_10;
            currentCharacterData = new CharacterSaveData();
            StartCoroutine(LoadWorldScene());
            return;
        }

        // If there are no free slots, notify the player
        TitleScreenManager.instance.DisplayNoFreeSlotsPopUp();
    }

    public void LoadGame() {
        saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(currentCharacterSlotUsed);

        saveFileDataWriter = new SaveFileDataWriter();
        // Generally Works on Most Machine Types
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;
        saveFileDataWriter.saveFileName = saveFileName;
        currentCharacterData = saveFileDataWriter.LoadSaveFile();

        StartCoroutine(LoadWorldScene());

    }

    public void SaveGame() {
        // Save The Current File under A File Name Depending on Which Slot is Being Used
        saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(currentCharacterSlotUsed);

        saveFileDataWriter = new SaveFileDataWriter();
        // Generally Works on Most Machine Types
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;
        saveFileDataWriter.saveFileName = saveFileName;

        // Pass the player's info, from the game to the save file
        player.SaveGameDataToCurrentCharacterData(ref currentCharacterData);

        saveFileDataWriter.CreateNewCharSaveFile(currentCharacterData);
    }

    public void DeleteGame(CharacterSlot characterSlot) {
        saveFileDataWriter = new SaveFileDataWriter();
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;
        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
        saveFileDataWriter.DeleteSaveFile();
    }

    // Load all character profiles on device when starting game
    private void LoadAllCharacterProfiles() {
        saveFileDataWriter = new SaveFileDataWriter();
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_01);
        characterSlot01 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_02);
        characterSlot02 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_03);
        characterSlot03 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_04);
        characterSlot04 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_05);
        characterSlot05 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_06);
        characterSlot06 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_07);
        characterSlot07 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_08);
        characterSlot08 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_09);
        characterSlot09 = saveFileDataWriter.LoadSaveFile();

        saveFileDataWriter.saveFileName = DecideFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.characterSlot_10);
        characterSlot10 = saveFileDataWriter.LoadSaveFile();        
    }

    public IEnumerator LoadWorldScene() {
        // If you want only one world scene, use this.
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);

        // If you want to use different scenes for levels, use this.
        // AsyncOperation loadOperation = SceneManager.LoadSceneAsync(currentCharacterData.sceneIndex);
        player.LoadGameDataFromCurrentCharacterData(ref currentCharacterData);
        yield return null;
    }

    public int GetWorldSceneIndex() {
        return worldSceneIndex;
    }
}
