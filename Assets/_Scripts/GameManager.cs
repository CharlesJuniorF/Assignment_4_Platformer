using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public static int lives;
    public static int score = 0;
    public static int livesPerGame = 5;

    public static bool _paused;
    public static bool _gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                _paused = true;
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                _paused = false;
            }
        }
    }

    public static void SubtractLife()
    {
        lives--;

        if (lives == 0)
        {
            Debug.Log("game over");
            _gameOver = true;
        }
    }

    public static void StartGame()
    {
        GameManager.score = 0;
        GameManager.lives = 5;
        GameManager._gameOver = false;
        _paused = false;
    }
}
