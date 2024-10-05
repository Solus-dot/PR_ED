using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEffectsManager : CharacterEffectsManager {
    // Delete Later
    [SerializeField] InstantCharacterEffect testEffect;
    [SerializeField] bool processEffect = false;
    
    private void Update() {
        if (processEffect) {
            processEffect = false;
            TakeStaminaDamageEffect effect = Instantiate(testEffect) as TakeStaminaDamageEffect;
            ProcessInstantEffect(effect);
        }
    }
}
