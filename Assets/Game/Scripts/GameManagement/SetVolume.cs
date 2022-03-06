using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume: MonoBehaviour {

    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    public void setVolume() {
        GameManager.Instance.volume = slider.value;
    }
}
