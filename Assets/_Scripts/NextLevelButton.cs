using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public string nextLevel = "Level0_";

    public void OnClick()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
