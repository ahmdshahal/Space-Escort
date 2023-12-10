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
    public bool isPlaying;

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
        Resume();
    }

    public void Addscore(int addedScore)
    {
        score += addedScore;
        //scoreText.text = score.ToString();
    }

    public void GameOverScreen()
    {
        Pause();
        StartCoroutine(PlayGameOver());
    }

    public void UpgradePanel()
    {
        upgradePanel.gameObject.SetActive(true);
        Pause();
    }

    public void Resume()
    {
        isPlaying = true;
    }

    public void Pause()
    {
        isPlaying = false;
    }

    public void GameClearScreen()
    {
        Pause();
        StartCoroutine(PlayGameClear());
    }

    IEnumerator PlayGameClear()
    {
        SoundManagerScript.instance.Playsound(4);
        GameClearPanel.SetActive(true);

        yield return new WaitForSeconds(SoundManagerScript.instance.GetSoundLength(4));
    }

    IEnumerator PlayGameOver()
    {
        SoundManagerScript.instance.Playsound(5);
        GameOverPanel.SetActive(true);

        yield return new WaitForSeconds(SoundManagerScript.instance.GetSoundLength(5));
    }
}
