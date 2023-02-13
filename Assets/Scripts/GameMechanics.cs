using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMechanics : MonoBehaviour
{
    private bool isGameFinished;
    public Text scoreText;
    private float score, scoreSpeed;
    private int currentLevel;

    [SerializeField] private List<int> LevelSpeed, LevelMax;

    void Awake()
    {
        GameManager.Instance.isInitialized = true;


        score = 0f;
        currentLevel = 0;
        scoreText.text = ((int)score).ToString();
        scoreSpeed = LevelSpeed[currentLevel];
    }
    void Update()
    {
        if (isGameFinished) return;

        score += scoreSpeed * Time.deltaTime;
        scoreText.text = ((int)score).ToString();

        if (score > LevelMax[Mathf.Clamp(currentLevel, 0, LevelMax.Count - 1)])
        {
            currentLevel = Mathf.Clamp(currentLevel, 0, LevelMax.Count - 1);
            scoreSpeed = LevelSpeed[currentLevel];
        }
    }
    public void GameEnded()
    {
        isGameFinished = true;
        GameManager.Instance.CurrentScore = (int)score;
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GotoMainMenu();
    }



}
