using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public static ExpBar instance;
    
    [SerializeField] private Slider expBar;
    [SerializeField] private float maxExp;

    private float _currentExp;

    private void Awake()
    {
        instance = this;
        SetUIExp();
    }

    public void AddExpPoint(float amount)
    {
        _currentExp += amount;
        SetUIExp();

        if (_currentExp >= maxExp)
        {
            //Muncul pop up upgrade
        }
    }

    private void SetUIExp()
    {
        expBar.value = _currentExp / maxExp;
    }
}