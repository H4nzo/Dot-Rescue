using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Text scoreText, bestScore, newBestScore;

    void Start()
    {
            scoreText.text = "0";
    }
}
