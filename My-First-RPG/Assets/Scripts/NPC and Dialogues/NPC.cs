using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactive
{
    public string npcName;
    private Dialogue npcDialogue;
    public bool npcMission;
    public string missionId;

    public override void Interact()
    {
        //Write the npc´s dialogue
        string npcNoSpacesName = npcName.Replace(" ", "");
       
        if (npcDialogue == null)
            npcDialogue = DialogueManager.sharedInstance.dialogues[npcNoSpacesName + "_S"];

        if (npcMission)
            Missions_Texts.sharedInstance.AddMission(MissionsManager.sharedInstance.missions[missionId]);

        if (MissionsManager.sharedInstance.missions[missionId].completed) { 
            npcDialogue = DialogueManager.sharedInstance.dialogues[npcNoSpacesName + "_E"];
            Missions_Texts.sharedInstance.ClearMission(MissionsManager.sharedInstance.missions[missionId]); //The mission will be marked as "cleared" by painting it in green
            DialogueBox.sharedInstance.dialogueIndex = 0; //We have to reset the index so the NPC tells the new dialogue (it will be set to zero every time we speak with him)
        }

        DialogueBox.sharedInstance.StartDialogue(npcName, npcDialogue);
    }
}
