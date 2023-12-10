using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private GameObject GameClearPanel;

    [SerializeField] private GameObject upgradePanel;

    public int score;
    public bool isGameplay = true;

    public static GameplayManager instance;

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
        GameOverPanel.SetActive(false);
        upgradePanel.gameObject.SetActive(false);

        isGameplay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameplay)
        {
            Time.timeScale = 0;
        }
    }

    public void Addscore(int addedScore)
    {
        score += addedScore;
        //scoreText.text = score.ToString();
    }

    public void GameOverScreen()
    {
        StartCoroutine(PlayGameOver());
    }

    public void UpgradePanel()
    {
        upgradePanel.gameObject.SetActive(true);
        isGameplay = false;
    }

    public void unPause()
    {
        isGameplay = true;
        Time.timeScale = 1;
    }

    public void GameClearScreen()
    {
        Debug.Log("GameClear");

        StartCoroutine(PlayGameClear());
    }

    IEnumerator PlayGameClear()
    {
        SoundManagerScript.instance.Playsound(4);
        GameClearPanel.SetActive(true);

        yield return new WaitForSeconds(SoundManagerScript.instance.GetSoundLength(4));
        isGameplay = false;
    }

    IEnumerator PlayGameOver()
    {
        SoundManagerScript.instance.Playsound(5);
        GameOverPanel.SetActive(true);

        yield return new WaitForSeconds(SoundManagerScript.instance.GetSoundLength(5));
        isGameplay = false;
    }
}
