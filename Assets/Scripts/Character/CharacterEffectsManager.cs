using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffectsManager : MonoBehaviour {
    // Process Instant Effects (Damage, Healing)
    // Process Timed Effects (Poison, Build ups)
    // Process Static Effects (Buffs, Debuffs)

    CharacterManager character;

    private void Awake() {
        character = GetComponent<CharacterManager>();
    }

    public virtual void ProcessInstantEffect(InstantCharacterEffect effect) {
        effect.ProcessEffect(character);
    }
}
