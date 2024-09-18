using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// Since we want to reference this data for every save file
// This script is not a monobehaviour and is serializable
public class CharacterSaveData {
    [Header("Character Name")]
    public string characterName;

    [Header("Time Played")]
    public float secondsPlayed;

    // We can only store data from basic variable types
    [Header("World Coordinates")]
    public float xPos;
    public float yPos;
    public float zPos;

}
