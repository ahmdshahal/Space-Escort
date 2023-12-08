using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int projectileDamage = 50;
    [SerializeField] private int missileSpeed = 10;
    [SerializeField] private float _lifeTime = 2.0f;

    private float _currentMissileSpeed;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        Invoke("ReturnToPool", _lifeTime);
        _meshRenderer.enabled = true;
        _currentMissileSpeed = missileSpeed;
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward *(_currentMissileSpeed*Time.deltaTime));
    }
}
