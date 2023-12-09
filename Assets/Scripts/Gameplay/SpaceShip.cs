using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private MeshRenderer shipRenderer;
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
            StartCoroutine(Dead());
            //GameOver
        }
    }

    private void SetUIHealth()
    {
        healthBar.value = _currentHealth / health;
    }
    
    private IEnumerator Dead()
    {
        explosionEffect.Play();

        shipRenderer.enabled = false;
        
        ParticleSystem.MainModule mainModule = explosionEffect.main;
        yield return new WaitForSeconds(mainModule.duration);
        
        gameObject.SetActive(false);
    }
}
