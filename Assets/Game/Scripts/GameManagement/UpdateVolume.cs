using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateVolume: MonoBehaviour {

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        audioSource.volume = GameManager.Instance.volume;
    }
}
