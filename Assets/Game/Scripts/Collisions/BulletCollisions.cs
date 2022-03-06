using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions: MonoBehaviour {

    public Player player;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            Destroy(gameObject);
            player.Health.LoseHealth(15f);
        }
        if (other.collider.tag == "Wall")
            Destroy(gameObject);
    }
}
