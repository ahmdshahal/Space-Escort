using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    public static UpgradeStats instance;
    public float missileSpeed = 10;
    public float fireRate = 1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeMissileSpeed(float upgradePercentage)
    {
        missileSpeed *= (1.0f + upgradePercentage / 100f);
    }

    public void UpgradeFireRate(float upgradePercentage)
    {
        fireRate *= (1.0f - upgradePercentage / 100);
    }
}
