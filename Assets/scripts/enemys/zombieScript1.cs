using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class zombieScript1 : MonoBehaviour
{
  
    public Flowchart flowchart;   
    void OnTriggerEnter2D(Collider2D other)
    {
     
            flowchart.SendFungusMessage("zombie1");
      
    }
    public void attackZombie()
    {
      
        globalVariable.addObjectToList("zombie1");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = 20;
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = 15;
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = 20;
        globalSlots.slot9T = "z1";
    }
    }
