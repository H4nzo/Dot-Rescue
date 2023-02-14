using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]float minRotSpeed, maxRotSpeed;
    float currentRotSpeed;

    [SerializeField]float minRotTime, maxRotTime;
    float rotTime;
    float currentRotTime;

    void Awake()
    {
        currentRotTime = 0f;
        currentRotSpeed = minRotSpeed + (maxRotSpeed - minRotSpeed) * 0.1f * Random.Range(0,11);
        rotTime = minRotTime + (maxRotTime - minRotTime) * 0.1f * Random.Range(0,11);
        currentRotSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
    }

    void Update()
    {
        currentRotTime += Time.deltaTime;

        if (currentRotTime > rotTime)
        {
            currentRotTime = 0f;
            currentRotSpeed = minRotSpeed + (maxRotSpeed - minRotSpeed) * 0.1f * Random.Range(0, 11);
            rotTime = minRotTime + (maxRotTime - minRotTime) * 0.1f * Random.Range(0, 11);
            currentRotSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
        }
    }
    
    void FixedUpdate()
    {
        transform.Rotate(0, 0, currentRotSpeed * Time.fixedDeltaTime);
    }
    





}
