using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharacterSaveSlot : MonoBehaviour {
    SaveFileDataWriter saveFileDataWriter;

    [Header("Game Slot")]
    public CharacterSlot characterSlot;

    [Header("Character Info")]
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI timePlayed;

    private void OnEnable() {
        LoadSaveSlots();
    }

    private void LoadSaveSlots() {
        saveFileDataWriter = new SaveFileDataWriter();
        saveFileDataWriter.SaveDataDirPath = Application.persistentDataPath;

        switch(characterSlot) {
            case CharacterSlot.characterSlot_01:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot01.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_02:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot02.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_03:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot03.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_04:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot04.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_05:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot05.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_06:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot06.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_07:
               saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot07.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_08:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot08.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_09:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);

                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot09.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            case CharacterSlot.characterSlot_10:
                saveFileDataWriter.saveFileName = SaveGameManager.instance.DecideFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckIfFileExists()) {
                    characterName.text = SaveGameManager.instance.characterSlot10.characterName;
                } else {
                    gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    public void LoadGameFromCharacterSlot() {
        SaveGameManager.instance.currentCharacterSlotUsed = characterSlot;
        SaveGameManager.instance.LoadGame();
    }

    public void SelectCurrentSlot() {
        TitleScreenManager.instance.SelectCharacterSlot(characterSlot);
    }
}
