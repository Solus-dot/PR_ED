using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
