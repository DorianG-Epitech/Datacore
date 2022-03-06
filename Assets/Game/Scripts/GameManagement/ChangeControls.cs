using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeControls: MonoBehaviour {

    public GameObject alertInput;
    public string waitForInput = null;

    void Start() {
        
    }

    void Update() {
        if (alertInput.activeSelf == false)
            return;
        string currentInput = Input.inputString;
        // if (currentInput != "") {
        //     if (waitForInput == "UP")
        //         GameManager.Instance.upKey = currentInput;
        //     if (waitForInput == "DOWN")
        //         GameManager.Instance.downKey = currentInput;
        //     if (waitForInput == "LEFT")
        //         GameManager.Instance.leftKey = currentInput;
        //     if (waitForInput == "RIGHT")
        //         GameManager.Instance.rightKey = currentInput;
        //     alertInput.SetActive(false);
        //     waitForInput = null;
        // }
    }

    public void setWaitForInput(string newWaitForInput) {
        waitForInput = newWaitForInput;
        alertInput.SetActive(true);
    }
}