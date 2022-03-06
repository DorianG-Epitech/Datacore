using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ModifyBloom: MonoBehaviour {
    public GetAudioValues audioValues;
    public Volume volume;
    public Color[] loopColors;
    private Bloom bloom;
    public float colorSpeed = 1f;
    private float colorMove = 0f;
    private int colorOffset = 0;

    void Start() {
        volume.profile.TryGet(out bloom);
    }

    float newColorValue(float oldVal, float newVal) {
        float diff = Mathf.Abs(oldVal - newVal);
        float toAdd = (diff * colorMove) / 100f;
        return (oldVal < newVal) ? oldVal + toAdd : oldVal - toAdd;
    }

    void Update() {
        Color newBloomColor = new Color();
        Color oldColor = loopColors[colorOffset];
        Color newColor = loopColors[(colorOffset + 1 == loopColors.Length) ? 0 : colorOffset + 1];
        
        newBloomColor.r = newColorValue(oldColor.r, newColor.r);
        newBloomColor.g = newColorValue(oldColor.g, newColor.g);
        newBloomColor.b = newColorValue(oldColor.b, newColor.b);
        bloom.intensity.value = audioValues.medium * 10;
        bloom.scatter.value = audioValues.medium / 8;
        bloom.tint.value = newBloomColor;
        colorMove += colorSpeed * Time.deltaTime;
        if (colorMove >= 100f) {
            colorOffset = (colorOffset + 1 == loopColors.Length) ? 0 : colorOffset + 1;
            colorMove = 0f;
        }
    }
}
