using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class impScript1 : MonoBehaviour
{
  
   
    public Flowchart flowchart;
    
   
    void OnTriggerEnter2D(Collider2D other)
    {
        cameraScriptMap.playBattlemusic();
        if(globalSlots.slot2I<1)
        {
            flowchart.SendFungusMessage("needArcher");
        }
        else
        {
            flowchart.SendFungusMessage("imp1Attack");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        cameraScriptMap.stopBattlemusic();
    }
   public void attackImp()
    {
        globalSlots.slot8I = 20;
        globalSlots.slot8T = "BImp";
        globalSlots.slot9I = 10;
        globalSlots.slot9T = "RImp";
        globalSlots.slot10I = 20;
        globalSlots.slot10T = "BImp";
    }
    }
