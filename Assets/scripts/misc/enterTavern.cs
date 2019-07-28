using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class enterTavern : MonoBehaviour
{
    public Flowchart flowchart;
    void OnTriggerEnter2D(Collider2D other)
    {
        globalVariable.setPlayerCoordToSpec(-0.68f, -3.816f);
        flowchart.SendFungusMessage("enterTavern");
        
    }
    }
