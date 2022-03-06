using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer: MonoBehaviour {

    public Transform target;

    void Update() {
        transform.LookAt(target.position, Vector3.forward);
    }
}
