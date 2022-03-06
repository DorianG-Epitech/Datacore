using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager: MonoBehaviour {

    private Text scoreText;
    private int currentScore;

    private float deltaTime;

    void Awake() {
        scoreText = GetComponent<Text>();
    }

    void Update() {

        // deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        // float fps = 1.0f / deltaTime;
        // scoreText.text = Mathf.Ceil(fps).ToString();

        if (currentScore != GameManager.Instance.score) {
            string zeros = "";

            currentScore = GameManager.Instance.score;
            if (currentScore < 100)
                zeros += "0";
            if (currentScore < 10)
                zeros += "0";
            scoreText.text = $"Score: {zeros}{currentScore}";
        }
    }
}
