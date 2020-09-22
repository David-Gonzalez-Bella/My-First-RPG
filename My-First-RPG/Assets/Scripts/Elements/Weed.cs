using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : Interactive
{
    public override void Interact()
    {
        if (GameManager.sharedInstance.player.GetComponent<PlayerController>().activeMissions.Contains(MissionsManager.sharedInstance.missions["GetWeeds"]))
        {
            AudioManager.sharedInstance.OnWeedCollectedSound += AudioManager.sharedInstance.PlayWeedCollectedSound;
            Missions_Texts.sharedInstance.CheckUpdateMission(MissionsManager.sharedInstance.missions["GetWeeds"]);
            Destroy(this.gameObject);
        }
    }
}
