using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public int score = 0;
    public float volume = 1f;
    private static GameManager instance;

    private GameManager() { }

    public static GameManager Instance {
        get {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }
}
