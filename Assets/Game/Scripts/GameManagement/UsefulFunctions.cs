using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsefulFunctions: MonoBehaviour {
    public GameObject pauseScreen;

    public void ReloadLevel() {
        Time.timeScale = 1f;
        GameManager.Instance.score = 0;
        SceneManager.LoadScene("InGame");
    }

    public void unPause() {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

    public void exitGame() {
        Application.Quit();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }

    }
}
