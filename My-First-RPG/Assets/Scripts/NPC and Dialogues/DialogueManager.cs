﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager sharedInstance;

    public Dictionary<string, Dialogue> dialogues = new Dictionary<string, Dialogue>();
    public Dialogue firstMissionStart;
    public Dialogue firstMissionEnd;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        Initialize();

        //Now that the file exists (so we can modify it easily from there, thats the point of all this) we can deserialize it and add the Dialogue objects to the dictionary
        Dialogue[] deserializedObjs = SerializerXML.Deserialize<Dialogue[]>("Assets/Dialogues/dialogues.xml");
        foreach (Dialogue d in deserializedObjs)
        {
            dialogues[d.id] = d;
        }
    }

    private void Initialize()
    {
        //Inicialize dialogues
        firstMissionStart = new Dialogue { lines = new string[] { "hi!", "how are you?", "bye!" }, id = "LostWarrior_S" };
        firstMissionEnd = new Dialogue { lines = new string[] { "thankyou1", "thankyou3", "thankyou3" }, id = "LostWarrior_E" };

        //Serialize them, which means, create a xml document with its information if it does not exist already
        if (!System.IO.File.Exists("Assets/Dialogues/dialogues.xml"))
        {
            Debug.Log("Created!");
            Dialogue[] xmlFile = new Dialogue[] { firstMissionStart, firstMissionEnd };
            SerializerXML.Serialize("Assets/Dialogues/dialogues.xml", xmlFile);
        }

        
    }
}
