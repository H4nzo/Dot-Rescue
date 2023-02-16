using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class directionScript : MonoBehaviour
{
    [SerializeField] float timeFloat = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableText(timeFloat));
    }

    IEnumerator DisableText(float timeFloat)
    {
        yield return new WaitForSeconds(timeFloat);
        this.gameObject.SetActive(false);
    }


}
