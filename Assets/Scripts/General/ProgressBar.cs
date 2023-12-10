using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private float maxTime;

    private float _time;

    private void Update()
    {
        if (GameplayManager.instance.isPlaying)
        {
            _time += Time.deltaTime;
            SetUIProgress();

            if (_time >= maxTime)
            {
                //End Game
                GameplayManager.instance.GameClearScreen();
            }
        }
    }

    private void SetUIProgress()
    {
        progressBar.value = _time / maxTime;
    }
}
