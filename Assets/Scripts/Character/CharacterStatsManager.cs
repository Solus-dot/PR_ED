using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour {
    CharacterManager character;

    [Header("Stamina Regeneration")]
    [SerializeField] float staminaRegenAmount = 2;
    private float staminaRegenTimer = 0;
    private float staminaTickTimer = 0;
    [SerializeField] float staminaRegenDelay = 2;

    protected virtual void Awake() {
        character = GetComponent<CharacterManager>();
    }


    public int CalculateStaminaBasedOnEnduranceLevel(int endurance) {
        float stamina = endurance * 10;
        return Mathf.RoundToInt(stamina);
    }

    
    public virtual void RegenerateStamina() {
        if (!character.IsOwner) return;
        if (character.characterNetworkManager.isSprinting.Value) return;
        if (character.isPerformingAction) return;

        staminaRegenTimer += Time.deltaTime;

        if (staminaRegenTimer >= staminaRegenDelay) {
            if (character.characterNetworkManager.currentStamina.Value < character.characterNetworkManager.maxStamina.Value) {
                staminaTickTimer += Time.deltaTime;

                if (staminaTickTimer >= 0.1) {
                    staminaTickTimer = 0;
                    character.characterNetworkManager.currentStamina.Value += staminaRegenAmount;
                    if (character.characterNetworkManager.currentStamina.Value > character.characterNetworkManager.maxStamina.Value) {
                        character.characterNetworkManager.currentStamina.Value = character.characterNetworkManager.maxStamina.Value;
                    }
                }
            }
        }
    }

    public virtual void ResetStaminaRegenTimer(float prevStaminaAmount, float currStaminaAmount) {
        // We only want to regen stamina when a stamina-consuming action is used
        // We dont want to regen stamina when it is already regening
        if (currStaminaAmount < prevStaminaAmount) {
            staminaRegenTimer = 0;
        }
    }
}
