using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class wolftScript : MonoBehaviour
{
  
    public Flowchart flowchart;   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (globalSlots.slot1I < 1)
        {
            flowchart.SendFungusMessage("needKnight");
        }
        else
        {
            flowchart.SendFungusMessage("wolf1");
        }
    }
    public void attackWolf()
    {
      
        globalVariable.addObjectToList("wolfenemy1");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = 10;
        globalSlots.slot7T = "w1";
        globalSlots.slot8I = 15;
        globalSlots.slot8T = "w1";
    }
    }
