using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard;
    public GameObject[] livesCount;
    public GameObject gameOverSceen;

    private void Start()
    {
        gameOverSceen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager._gameOver)
        {
            gameOverSceen.SetActive(true);
            return;
        }

        scoreBoard.text = GameManager.score.ToString();

        //hide all tokens
        for (int i = 0; i < livesCount.Length; i++)
        {
            livesCount[i].SetActive(false);
        }

        //reveal all that are active
        for (int i = 0; i < GameManager.lives; i++)
        {
            livesCount[i].SetActive(true);
        }

    }
}
