using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisions : MonoBehaviour {
    public Player player;
    public PlayerGun playerGun;
    public GameObject BulletPrefab;

    void OnParticleCollision(GameObject other) {
        if (other.tag == "Player")
            player.Health.LoseHealth(15f);
        if (other.tag == "GunBarrel")
            playerGun.CatchBullet(BulletPrefab);
    }
}