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
        if (this.name == "zombie1")
        {
            flowchart.SendFungusMessage("zombie1");
        }
        if (this.name == "zombie2")
        {
            flowchart.SendFungusMessage("zombie2");
        }
        if (this.name == "zombie3")
        {
            flowchart.SendFungusMessage("zombie3");
        }
        if (this.name == "zombie4")
        {
            flowchart.SendFungusMessage("zombie4");
        }
        if (this.name == "zombie5")
        {
            flowchart.SendFungusMessage("zombie5");
        }
        if (this.name == "zombie6")
        {
            flowchart.SendFungusMessage("zombie6");
        }
        if (this.name == "zombie7")
        {
            flowchart.SendFungusMessage("zombie7");
        }
       
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
    public void attackZombie2()
    {
      
        globalVariable.addObjectToList("zombie2");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = Random.Range(9, 30);
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = Random.Range(9, 20);
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = Random.Range(10, 30);
        globalSlots.slot9T = "z1";
    }
    public void attackZombie3()
    {
      
        globalVariable.addObjectToList("zombie3");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = Random.Range(9, 30);
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = Random.Range(9, 20);
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = Random.Range(10, 30);
        globalSlots.slot9T = "z1";
    }
    public void attackZombie4()
    {
      
        globalVariable.addObjectToList("zombie4");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = Random.Range(9, 30);
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = Random.Range(9, 20);
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = Random.Range(10, 30);
        globalSlots.slot9T = "z1";
    }
    public void attackZombie5()
    {
      
        globalVariable.addObjectToList("zombie5");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = Random.Range(9, 30);
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = Random.Range(9, 20);
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = Random.Range(10, 30);
        globalSlots.slot9T = "z1";
    }
    public void attackZombie6()
    {
      
        globalVariable.addObjectToList("zombie6");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = Random.Range(9, 30);
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = Random.Range(9, 20);
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = Random.Range(10, 30);
        globalSlots.slot9T = "z1";
    }
    public void attackZombie7()
    {
      
        globalVariable.addObjectToList("zombie7");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = Random.Range(10,40);
        globalSlots.slot7T = "z1";
        globalSlots.slot8I = Random.Range(10, 40);
        globalSlots.slot8T = "z2";
        globalSlots.slot9I = Random.Range(10, 40);
        globalSlots.slot9T = "z1";
    }
    }
