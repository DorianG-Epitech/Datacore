using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeControlText: MonoBehaviour {
    private Text text;
    public enum InputType { UP, DOWN, LEFT, RIGHT };
    public InputType inputType;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        // switch (inputType) {
        //     case InputType.UP:
        //         text.text = GameManager.Instance.upKey;
        //         break;
        //     case InputType.DOWN:
        //         text.text = GameManager.Instance.downKey;
        //         break;
        //     case InputType.LEFT:
        //         text.text = GameManager.Instance.leftKey;
        //         break;
        //     case InputType.RIGHT: default:
        //         text.text = GameManager.Instance.rightKey;
        //         break;
        // }
    }
}
