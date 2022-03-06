using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour {

    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject controlPanel;

    void Start() {
        
    }

    void Update() {
        
    }

    public void OpenCloseOptions(string optionsAction) {
        mainPanel.SetActive(optionsAction == "CLOSE");
        optionPanel.SetActive(optionsAction == "OPEN");
    }

    public void OpenCloseControls(string controlsAction) {
        optionPanel.SetActive(controlsAction == "CLOSE");
        controlPanel.SetActive(controlsAction == "OPEN");
    }

    public void GoToScene(string sceneName) {
        print("GoToScene " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame() {
        Application.Quit();
        print("Close game");
    }
}
