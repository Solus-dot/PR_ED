using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatBar : MonoBehaviour {
    private Slider slider;

    protected virtual void Awake() {
        slider = GetComponent<Slider>();
    }

    public virtual void SetStat(int newValue) {
        slider.value = newValue;
    }

    public virtual void SetMaxStat(int maxValue) {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }
}
