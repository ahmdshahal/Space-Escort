using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform fireTransform;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate;

    private List<GameObject> _projectilePool = new();
    private int name;
    private float time;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            _projectilePool.Add(projectile);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= fireRate)
        {
            Fire();
            time = 0;
        }
    }

    private void Fire()
    {
        GameObject projectile = GetProjectileFromPool();
        if (projectile != null)
        {
            projectile.transform.position = fireTransform.position;
            projectile.transform.rotation = fireTransform.rotation;
            projectile.SetActive(true);
        }
    }

    private GameObject GetProjectileFromPool()
    {
        foreach (GameObject projectile in _projectilePool)
        {
            if (!projectile.activeInHierarchy)
                return projectile; 
        }

        return null;
    }

    public void UpgradeFireRate(float upgradePercentage)
    {
        fireRate *= (1.0f - upgradePercentage / 100);
    }
}
