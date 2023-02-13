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

    [SerializeField]private List<int> LevelSpeed, LevelMax;

    void Awake()
    {
        score = 0f;
        currentLevel = 0;
    }



}
