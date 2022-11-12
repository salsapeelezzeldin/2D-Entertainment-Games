using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 1f);
    }

    public void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }
}


