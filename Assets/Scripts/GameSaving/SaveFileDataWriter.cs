using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;
using UnityEngine;

public class SaveFileDataWriter {
    public string SaveDataDirPath = "";
    public string saveFileName = "";

    public bool CheckIfFileExists() {
        if (File.Exists(Path.Combine(SaveDataDirPath, saveFileName))) return true;
        else return false;
    }

    public void DeleteSaveFile() {
        File.Delete(Path.Combine(SaveDataDirPath, saveFileName));
    }

    public void CreateNewCharSaveFile(CharacterSaveData characterData) {
        // Make a path to save the file (location)
        string savePath = Path.Combine(SaveDataDirPath, saveFileName);

        try {
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
            Debug.Log("CREATING SAVE, AT SAVE PATH: " + savePath);

            // Serialize the C# Game data into JSON
            string dataToStore = JsonUtility.ToJson(characterData, true);

            // Write File to the system
            using (FileStream stream = new FileStream(savePath, FileMode.Create)) {
                using (StreamWriter fileWriter = new StreamWriter(stream)) {
                    fileWriter.Write(dataToStore);
                }
            }
        } catch (Exception ex) {
            Debug.LogError("ERROR TRYING TO SAVE, GAME NOT SAVED: " + savePath + "\n" + ex);
        }
    }

    public CharacterSaveData LoadSaveFile() {
        CharacterSaveData characterData = null;
        string loadPath = Path.Combine(SaveDataDirPath, saveFileName);

        if (File.Exists(loadPath)) {
            try {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(loadPath, FileMode.Open)) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Deserialize the data from JSON
                characterData = JsonUtility.FromJson<CharacterSaveData>(dataToLoad);
            } catch (Exception ex) {
                Debug.LogError("FILE IS BLANK. " + ex);
            }
        }
        
        return characterData;
    }
}
