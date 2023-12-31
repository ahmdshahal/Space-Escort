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
    [SerializeField] private UpgradeManager upgradeManager;

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
            SoundManagerScript.instance.Playsound(3);

            GameplayManager.instance.UpgradePanel();
            upgradeManager.ToggleUpgradePanel();
            _currentExp = 0;
            SetUIExp();
        }
    }

    private void SetUIExp()
    {
        expBar.value = _currentExp / maxExp;
    }
}
