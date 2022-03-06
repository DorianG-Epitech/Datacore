using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public float MaxHealth;
    public UnityEvent OnDeathEvents;
    protected float _currentHealth;

    protected virtual void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public virtual void LoseHealth(float damageValue)
    {
        _currentHealth -= damageValue;
        if (damageValue <= 0) {
            damageValue = 0;
            OnDeathEvents.Invoke();
        }
    }

    public virtual void GainHealth(float healingValue)
    {
        _currentHealth += healingValue;
        if (_currentHealth > MaxHealth)
            _currentHealth = MaxHealth;
    }
}
