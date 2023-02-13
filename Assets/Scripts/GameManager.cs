using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string highScoreKey = "HighScore";
    private int currentScore;

    public const string mainMenu = "MenuScene";
    public const string Gameplay = "Gameplay";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        currentScore = 0;
        isInitialized = false;
    }
    public bool isInitialized
    {
        get; set;
    }

    public int HighScore
    {

        get
        {
            return PlayerPrefs.GetInt(highScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }

    public int CurrentScore
    {
        get; set;
        // get
        // {
        //     return currentScore;
        // }
        // set
        // {
        //     currentScore = value;
        // }
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void GotoGameplay()
    {
        SceneManager.LoadScene(Gameplay);
    }


}
