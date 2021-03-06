﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    [SerializeField]
    GameObject SaveImage;

    [SerializeField]
    ExampleVariableStorage storage;

    [SerializeField]
    string file = "SaveFile";

    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    CameraBehaviour cameraBehaviour;

    [SerializeField]
    Inventory inventory;

    public List<DoorScript> doors;
    PlayerControls pC;

    void Start()
    {
        pC = FindObjectOfType<PlayerControls>();
    }

    private void Update()
    {
        if (pC.InputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                print("Saved");
                Save();
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                Load();
            }
        }
    }

    public void Save()
    {
        using (StreamWriter sw = new StreamWriter(file, false))
        {
            sw.WriteLine("x" + playerTransform.position.x + " " + playerTransform.position.y + " " + playerTransform.position.z);
            for (int i = 0; i < doors.Count; i++)
            {
                sw.WriteLine("D" + i + " " + doors[i].inBool);
            }

            for (int i = 0; i < inventory.inventory.Count; i++)
            {
                sw.WriteLine("I" + inventory.inventory[i].itemName);
            }

            foreach (string s in storage.GetVariableNames())
            {
                Yarn.Value variable = storage.GetValue(s);
                switch (variable.type)
                {
                    case Yarn.Value.Type.Number:
                        sw.WriteLine(s + " " + "Number" + " " + variable.AsNumber);
                        break;
                    case Yarn.Value.Type.String:
                        sw.WriteLine(s + " " + "String" + " " + variable.AsString);
                        break;
                    case Yarn.Value.Type.Bool:
                        sw.WriteLine(s + " " + "Bool" + " " + variable.AsBool);
                        break;
                    case Yarn.Value.Type.Variable:
                        sw.WriteLine(s + " " + "Variable" + " " + variable);
                        break;
                    case Yarn.Value.Type.Null:
                        sw.WriteLine(s + " " + "null" + " " + null);
                        break;
                    default:
                        break;
                }

            }

        }
        StartCoroutine(SaveSuccessful());
    }
    IEnumerator SaveSuccessful()
    {
        SaveImage.SetActive(true);
        yield return new WaitForSeconds(2);
        SaveImage.SetActive(false);

    }
    public void Load()
    {
        if (SceneManager.GetActiveScene().name != "Andres_SceneDesignArea")
            SceneManager.LoadScene("Andres_SceneDesignArea");
        try
        {
            using (StreamReader sr = new StreamReader(file))
            {

                string line;
                storage.Clear();
                while ((line = sr.ReadLine()) != null)
                {
                    switch (line[0])
                    {
                        case '$': //Yarn Variabel
                            //Laddar alla Yarn variabler och sparar dem i Variable Storage
                            string variableName = line.Substring(0, line.IndexOf(" "));
                            string variableTypeS = line.Substring(line.IndexOf(" ") + 1, line.LastIndexOf(" ") - line.IndexOf(" ") - 1);
                            Yarn.Value variable = new Yarn.Value();
                            string variableValue = line.Substring(line.LastIndexOf(" ") + 1);
                            switch (variableTypeS)
                            {
                                case "Number":
                                    variable = new Yarn.Value(Convert.ToInt32(variableValue));
                                    variable.type = Yarn.Value.Type.Number;
                                    break;
                                case "String":
                                    variable = new Yarn.Value(variableValue);
                                    variable.type = Yarn.Value.Type.String;
                                    break;
                                case "Bool":
                                    variable = new Yarn.Value(Convert.ToBoolean(variableValue));
                                    variable.type = Yarn.Value.Type.Bool;
                                    break;
                                case "Variable":
                                    variable = new Yarn.Value(variableValue);
                                    variable.type = Yarn.Value.Type.Variable;
                                    break;
                                case "null":
                                    variable.type = Yarn.Value.Type.Null;
                                    break;
                                default:
                                    break;
                            }
                            storage.SetValue(variableName, variable);
                            break;

                        case 'x': //Spelarkaraktärens position
                            string x = line.Substring(1, line.IndexOf(" "));
                            string y = line.Substring(line.IndexOf(" ") + 1, line.LastIndexOf(" ") - line.IndexOf(" ") - 1);
                            string z = line.Substring(line.LastIndexOf(" ") + 1);
                            Vector3 pos = new Vector3((float)Convert.ToDouble(x), (float)Convert.ToDouble(y), (float)Convert.ToDouble(z));

                            playerTransform.position = pos;
                            cameraBehaviour.SetFollow();
                            break;

                        case 'D': //Ute/Inne

                            int doorID = Convert.ToInt32(line.Substring(1, line.IndexOf(" ")));
                            bool inBool = Convert.ToBoolean(line.Substring(line.LastIndexOf(" ") + 1));

                            for (int i = 0; i < doors.Count; i++)
                            {
                                if (i == doorID)
                                {
                                    doors[i].WalkThroughDoor(inBool);
                                }
                            }

                            break;
                        case 'I':

                            string itemName = line.Substring(1);

                            inventory.AddItem(itemName);

                            break;

                        default:
                            break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            print("The file could not be read: ");
            print(e.Message);
        }
    }
}

// Andreas Halldin