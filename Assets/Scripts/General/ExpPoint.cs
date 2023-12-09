using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
    [SerializeField] private float expAmount;
    [SerializeField] private float lifetime;

    private void OnEnable()
    {
        Invoke("SetInactive", lifetime);
    }

    private void SetInactive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GetExp");
            CancelInvoke();
            SetInactive();
            ExpBar.instance.AddExpPoint(expAmount);
        }
    }
}
