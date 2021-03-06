﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
                                                                    /*By Björn Andersson*/
public class ChangePortrait : MonoBehaviour
{
    [SerializeField]
    AudioClip doctorClip, defaultClip;

    [SerializeField]
    Sprite[] sprites;

    SoundManager sM;

    void Start()
    {
        sM = FindObjectOfType<SoundManager>();
    }

    [YarnCommand("ChangePortrait")]
    public void ChangeSprite(string newSprite)          //Byter porträttet som visas under konversationer
    {
        if (newSprite == "UI_Portrait_DR")
        {
            StartCoroutine("AnimateDoctor");
            sM.musicClip = doctorClip;
        }
        else
        {
            sM.musicClip = defaultClip;
            StopCoroutine("AnimateDoctor");
            UpdateSprite(newSprite);
        }
       
    }

    void UpdateSprite(string newSprite)
    {
        foreach (Sprite sprite in this.sprites)
        {
            if (sprite.name == newSprite)
            {
                GetComponent<Image>().sprite = sprite;
            }
        }
    }

    IEnumerator AnimateDoctor()
    {
        UpdateSprite("docdocFRAME0");
        yield return new WaitForSeconds(0.2f);
        UpdateSprite("docdocFRAME1");
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("AnimateDoctor");
    }
}