using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                                //By Timmy Alvelöv
public class OpenControlsMenu : MonoBehaviour
{
    bool toggle;
    public void SetItOn()
    {
        toggle = !toggle;
        gameObject.SetActive(toggle);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

}
