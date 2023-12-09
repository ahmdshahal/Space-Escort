using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private int enemyDamage = 5;
    [SerializeField] private float enemyHealth = 10;
    
    public float moveSpeed = 5;

    private MeshRenderer _meshRenderer;
    private Vector3 _targetTransform;
    private float _currentHealth;
    private float _currentSpeed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _targetTransform = Vector3.zero;
    }

    private void OnEnable()
    {
        _meshRenderer.enabled = true;
        _currentHealth = enemyHealth;
        _currentSpeed = moveSpeed;
    }

    private void Update()
    {
        if (_targetTransform != null)
        {
            Vector3 direction = _targetTransform - transform.position;
            direction.Normalize();

            transform.Translate(direction * (_currentSpeed * Time.deltaTime));
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            //Death condition
            StartCoroutine(Dead());
        }
    }

    private IEnumerator Dead()
    {
        explosionEffect.Play();

        _meshRenderer.enabled = false;
        _currentSpeed = 0;
        
        ParticleSystem.MainModule mainModule = explosionEffect.main;
        yield return new WaitForSeconds(mainModule.duration);
        
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SpaceShip"))
        {
            if (other.gameObject.TryGetComponent(out SpaceShip spaceShip))
            {
                spaceShip.TakeDamage(enemyDamage);
                StartCoroutine(Dead());
            }
        }
    }
}
