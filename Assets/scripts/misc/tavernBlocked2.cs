using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class tavernBlocked2 : MonoBehaviour
{
    public Flowchart flowchart;

    void OnTriggerEnter2D(Collider2D other)
    {

        flowchart.SendFungusMessage("tavernBlocked2");
        cameraScriptMap.playTavernmusic();
        

    }
    void OnTriggerExit2D(Collider2D other)
    {

      
        cameraScriptMap.playRaisOftheDeath();

    }
}
