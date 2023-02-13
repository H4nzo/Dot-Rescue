using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] AudioClip moveClip, loseClip;

    [SerializeField] GameMechanics gm;
    [SerializeField] GameObject explosivePrefab;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySound(moveClip);
            rotateSpeed *= -1f;
        }

    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(explosivePrefab, transform.GetChild(0).position, Quaternion.identity);
            SoundManager.Instance.PlaySound(loseClip);
            gm.GameEnded();
            Destroy(gameObject);
        }
    }
}

