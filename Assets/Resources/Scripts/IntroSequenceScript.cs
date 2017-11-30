using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                                                        //By Björn Andersson
public class IntroSequenceScript : MonoBehaviour
{

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    float timer;

    void Awake()
    {
        StartCoroutine("DestroyMe");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine("DestoyMe");
            canvas.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(timer);
        canvas.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
