using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private float health;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = health;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        SetUIHealth();

        if (_currentHealth <= 0)
        {
            //GameOver
        }
    }

    private void SetUIHealth()
    {
        healthBar.value = _currentHealth / health;
    }
}
