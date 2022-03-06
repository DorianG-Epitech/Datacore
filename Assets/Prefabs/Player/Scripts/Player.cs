using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject deathScreen;
    public Text scoreText;
    [HideInInspector] public PlayerHealth Health;

	private void Awake()
    {
        Health = GetComponent<PlayerHealth>();
	}

    public void GameOver()
    {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
        scoreText.text = $"Your score: {GameManager.Instance.score}";
    }
}