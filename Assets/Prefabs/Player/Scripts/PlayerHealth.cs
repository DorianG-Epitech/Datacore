using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Collider2D))]
public class PlayerHealth : HealthManager
{
    public Image HealthBar;
    private Animator c_animator;

    protected override void Awake()
    {
        base.Awake();
        c_animator = GetComponent<Animator>();
    }

    public override void LoseHealth(float damageValue)
    {
        c_animator.SetTrigger("Hitted");
        base.LoseHealth(damageValue);
        UpdateHealthBar();
    }

    public override void GainHealth(float healingValue)
    {
        c_animator.SetTrigger("Hitted");
        base.GainHealth(healingValue);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        HealthBar.rectTransform.sizeDelta = new Vector2(_currentHealth * 5, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 13) {
            GainHealth(20f);
            Destroy(other.collider.gameObject);
        }
    }
}
