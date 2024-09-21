using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Since we want to reference this data for every save file
// This script is not a monobehaviour and is serializable
[System.Serializable]
public class CharacterSaveData {
    [Header("Scene Index")]
    public int sceneIndex = 1;

    [Header("Character Name")]
    public string characterName = "Character";

    [Header("Time Played")]
    public float secondsPlayed;

    // We can only store data from basic variable types
    [Header("World Coordinates")]
    public float xPos;
    public float yPos;
    public float zPos;

}
