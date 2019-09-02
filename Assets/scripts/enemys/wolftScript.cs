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
        if (this.name == "wolfenemy1")
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
        if (this.name == "wolfenemy2")
        {
            
                flowchart.SendFungusMessage("wolf2");
            
        }
        Debug.Log(this.name);
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
    public void attackWolf2()
    {
      
        globalVariable.addObjectToList("wolfenemy2");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = 20;
        globalSlots.slot7T = "w1";
        globalSlots.slot8I = 15;
        globalSlots.slot8T = "w2";
        globalSlots.slot9I = 30;
        globalSlots.slot9T = "w1";
        string loadcount = db.readTheData(17);
        int loadcount_I = int.Parse(loadcount);
        loadcount_I--;
        db.addThingToList(17, loadcount_I.ToString());
    }
    }
