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
}


