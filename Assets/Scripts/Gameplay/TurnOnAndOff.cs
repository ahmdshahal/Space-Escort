using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnAndOff : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;

    private bool panelIsEnable;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnAndOff);
        panelIsEnable = false;
        pause.SetActive(panelIsEnable);
    }

    // Update is called once per frame
    private void OnAndOff()
    {
        panelIsEnable ^= true;
        pause.SetActive(panelIsEnable);

        if(panelIsEnable == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
