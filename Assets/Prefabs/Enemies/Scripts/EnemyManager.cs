using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour {

    public Player player;
    public PlayerGun playerGun;
    public GameObject enemyPrefab;
    public ParticleCollisions particleCollisions;
    public GameObject healthPrefab;
    public float spawnHealthProb = 1f;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            player.Health.LoseHealth(10f);
        }
        if (other.collider.tag == "GoodBullet") {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-1f, 18f), Random.Range(-5f, 5f), 0f), Quaternion.Euler(Vector3.zero));
            EnemyManager newEnemyManager = newEnemy.GetComponent<EnemyManager>();
            newEnemyManager.player = player;
            newEnemyManager.particleCollisions.player = player; 
            newEnemyManager.particleCollisions.playerGun = playerGun;
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.Instance.score += 50;
            if (Random.Range(0, 1) < spawnHealthProb)
                Instantiate(healthPrefab, transform.position, Quaternion.Euler(Vector3.zero));
        }
    }
}
