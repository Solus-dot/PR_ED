using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour {
    public static SaveGameManager instance;

    [SerializeField] PlayerManager player;

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

    private void DecideFileNameBasedOnCharacterSlotBeingUsed() {
        switch (currentCharacterSlotUsed) {
            case CharacterSlot.characterSlot_01:
                saveFileName = "CharacterSlot_01";
                break;
            case CharacterSlot.characterSlot_02:
                saveFileName = "CharacterSlot_02";
                break;
            case CharacterSlot.characterSlot_03:
                saveFileName = "CharacterSlot_03";
                break;
            case CharacterSlot.characterSlot_04:
                saveFileName = "CharacterSlot_04";
                break;
            case CharacterSlot.characterSlot_05:
                saveFileName = "CharacterSlot_05";
                break;
            case CharacterSlot.characterSlot_06:
                saveFileName = "CharacterSlot_06";
                break;
            case CharacterSlot.characterSlot_07:
                saveFileName = "CharacterSlot_07";
                break;
            case CharacterSlot.characterSlot_08:
                saveFileName = "CharacterSlot_08";
                break;
            case CharacterSlot.characterSlot_09:
                saveFileName = "CharacterSlot_09";
                break;
            case CharacterSlot.characterSlot_10:
                saveFileName = "CharacterSlot_10";
                break;
            default:
                break;
        }
    }

    public void CreateNewGame() {
        DecideFileNameBasedOnCharacterSlotBeingUsed();
        currentCharacterData = new CharacterSaveData();
    }

    public void LoadGame() {
        DecideFileNameBasedOnCharacterSlotBeingUsed();

        saveFileDataWriter = new SaveFileDataWriter();
        // Generally Works on Most Machine Types
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;
        saveFileDataWriter.saveFileName = saveFileName;
        currentCharacterData = saveFileDataWriter.LoadSaveFile();

        StartCoroutine(LoadWorldScene());

    }

    public void SaveGame() {
        // Save The Current File under A File Name Depending on Which Slot is Being Used
        DecideFileNameBasedOnCharacterSlotBeingUsed();

        saveFileDataWriter = new SaveFileDataWriter();
        // Generally Works on Most Machine Types
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;
        saveFileDataWriter.saveFileName = saveFileName;

        // Pass the player's info, from the game to the save file
        player.SaveGameDataToCurrentCharacterData(ref currentCharacterData);

        saveFileDataWriter.CreateNewCharSaveFile(currentCharacterData);
    }

    public IEnumerator LoadWorldScene() {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
        yield return null;
    }

    public int GetWorldSceneIndex() {
        return worldSceneIndex;
    }
}
