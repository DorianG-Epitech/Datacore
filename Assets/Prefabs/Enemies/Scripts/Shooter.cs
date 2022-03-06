using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour {

    public GameObject prefabBullet;
    public Player player;
    public float shootSpeed = 1f;
    public float bulletSpeed = 1f;
    public Vector2 bulletDirection;
    private float elapsedTime;

    void Start() {
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= shootSpeed) {
            elapsedTime %= shootSpeed;
            ShootBullet();
        }
    }

    void ShootBullet() {
        GameObject bullet = Instantiate(prefabBullet, transform.position, Quaternion.Euler(Vector3.zero));
        bullet.GetComponent<BulletCollisions>().player = player;
        bullet.GetComponent<Rigidbody2D>().velocity = (bulletDirection.normalized * bulletSpeed);
    }
}
