using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomIcon : MonoBehaviour
{
    [SerializeField] private GameObject[] icons;

    private void Start()
    {
        int randomIndex = Random.Range(0, icons.Length);
        icons[randomIndex].SetActive(true);
    }
}
