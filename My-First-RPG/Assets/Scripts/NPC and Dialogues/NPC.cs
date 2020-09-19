using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactive
{
    public string npcName;

    public override void Interact()
    {
        Debug.Log(npcName.Trim() + "_S");
        //DialogueBox.sharedInstance.StartDialogue(npcName, DialogueManager.sharedInstance.dialogues[npcName.Trim() + "_S"]);
    }
}
