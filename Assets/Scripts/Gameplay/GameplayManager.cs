using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject GameOverPanel;
    public int score;
    public bool isGameplay;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Addscore(int addedScore)
    {
        score += addedScore;
        //scoreText.text = score.ToString();
    }

    public void GameOverScreen()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
