using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSequenceScript : MonoBehaviour
{

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    float timer;

    void Awake()
    {
        print("being destroyed");
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
        print(timer);
        yield return new WaitForSeconds(timer);
        print("BOOM");
        canvas.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
