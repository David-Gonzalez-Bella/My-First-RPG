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
        DialogueBox.sharedInstance.dialogueIndex = 0;

        if (npcDialogue == null)
            npcDialogue = DialogueManager.sharedInstance.dialogues[npcNoSpacesName + "_S"];

        if (npcMission)
        {
            Missions_Texts.sharedInstance.AddMission(MissionsManager.sharedInstance.missions[missionId]);

            if (MissionsManager.sharedInstance.missions[missionId].completed)
            {
                npcDialogue = DialogueManager.sharedInstance.dialogues[npcNoSpacesName + "_E"];
                Missions_Texts.sharedInstance.ClearMission(MissionsManager.sharedInstance.missions[missionId]); //The mission will be marked as "cleared" by painting it in green
                GameManager.sharedInstance.player.GetComponent<Experience>().experience += MissionsManager.sharedInstance.missions[missionId].exp; //Once we clear a mission, we will recieve XP
                if (MissionsManager.sharedInstance.missions[missionId].id == "FirstMission")//Check if its the mission that clears the path
                {
                    Rocks.sharedInstance.ClearPath();
                }
            }
        }
        DialogueBox.sharedInstance.StartDialogue(npcName, npcDialogue);
    }
}
