using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeBulletType : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletType;
    public void UpgradeBullet(int selectedIndex)
    {
        for (int i = 0; i < bulletType.Length; i++)
        {
            // Activate the selected bullet type
            if (i == selectedIndex)
            {
                bulletType[i].SetActive(true);
            }
            else
            {
                // Deactivate other bullet types
                bulletType[i].SetActive(false);
            }
        }
    }
}
