using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSequenceScript : MonoBehaviour {

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    float timer;

    void Start()
    {
        StartCoroutine("DestroyMe");
    }
    
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(timer);
        canvas.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
