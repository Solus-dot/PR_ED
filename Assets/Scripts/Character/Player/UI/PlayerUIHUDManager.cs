using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIHUDManager : MonoBehaviour {
    [SerializeField] UIStatBar staminaBar;

    public void SetNewStaminaValue(float oldValue, float newValue) {
        staminaBar.SetStat(Mathf.RoundToInt(newValue));
    }

    public void SetMaxStaminaValue(int maxStamina) {
        staminaBar.SetMaxStat(maxStamina);
    }
}
