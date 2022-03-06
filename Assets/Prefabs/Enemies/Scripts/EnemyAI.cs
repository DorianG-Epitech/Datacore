using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI: MonoBehaviour {

    public Transform target;
    public float maxSpeed = 1f;
    public float minDistance = 5f;
    public ParticleSystem ps;
    private Rigidbody2D rb2d;
    private Animator animator;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        Vector2 newVelocity = transform.position - target.position;

        animator.SetBool("Walking", (newVelocity.magnitude < minDistance));
        if (newVelocity.magnitude > minDistance) {
            rb2d.velocity = Vector2.zero;
            if (ps.isStopped)
                ps.Play();
        if (transform.position.x > target.position.x)
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        if (transform.position.x < target.position.x)
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            return;
        }
        newVelocity.Normalize();
        newVelocity *= maxSpeed;
        if (newVelocity.x > 0f && transform.localRotation.eulerAngles.y == 0f)
            transform.Rotate(new Vector3(0f, 180f, 0f));
        if (newVelocity.x < 0f && transform.localRotation.eulerAngles.y == 180f)
            transform.Rotate(new Vector3(0f, -180f, 0f));
        if (ps.isPlaying)
            ps.Stop();
        rb2d.velocity = newVelocity;
    }
}
