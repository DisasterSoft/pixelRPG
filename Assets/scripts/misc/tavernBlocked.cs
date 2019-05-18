using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class tavernBlocked : MonoBehaviour
{
    public Flowchart flowchart;

    void OnTriggerEnter2D(Collider2D other)
    {

        flowchart.SendFungusMessage("tavernBlocked");
        cameraScriptMap.playTavernmusic();
        

    }
    void OnTriggerExit2D(Collider2D other)
    {

      
        cameraScriptMap.stopBattlemusic();

    }
}
