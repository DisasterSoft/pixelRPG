using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Fungus;
public class knightScripts : MonoBehaviour
{
   
    public Flowchart flowchart;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        globalVariable.addObjectToList("knight1");
        flowchart.SendFungusMessage("knight1");
       
    }
    public void setKnight()
    {
        globalSlots.setSlot1(40);
        globalSlots.setSlot1Type("k");
    }
}


