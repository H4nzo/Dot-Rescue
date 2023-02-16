using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Text scoreText, bestScoreText, newBestText;

    [SerializeField] float animationTime;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private AudioClip clickedClip;

    void Awake()
    {
        bestScoreText.text = GameManager.Instance.HighScore.ToString();
        if (!GameManager.Instance.isInitialized)
        {
            scoreText.gameObject.SetActive(false);
            // bestScoreText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    IEnumerator ShowScore()
    {
        int tempScore = 0;
        scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        if (highScore < currentScore)
        {
            // newBestText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            newBestText.gameObject.SetActive(false);
        }
        bestScoreText.text = GameManager.Instance.HighScore.ToString();

        float speed = 1 / animationTime;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)speedCurve.Evaluate(timeElapsed) * currentScore;
            scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        scoreText.text = tempScore.ToString();
    }

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(clickedClip);
        GameManager.Instance.GotoGameplay();
    }




























}
