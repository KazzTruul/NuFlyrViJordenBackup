﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    //list of all items in game
    public List<Item> items = new List<Item>();

    private void Start()
    {
        items.Add(new Item("Crushed_Larvae", 0 , "Crushed Larvae."));
        items.Add(new Item("Syringe", 1, "Syringe for injecting drugs."));
        items.Add(new Item("Vaccine", 2, "Vaccine against diseases."));
    }
}

// Stina Hedman