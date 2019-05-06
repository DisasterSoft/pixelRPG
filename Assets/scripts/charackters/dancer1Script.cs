using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class dancer1Script : MonoBehaviour
{
    public Flowchart flowchart;
    void OnTriggerEnter2D(Collider2D other)
    {
        globalVariable.addObjectToList("dancers1");
        flowchart.SendFungusMessage("Dancer1");
        globalVariable.setCard("1");
    }
}
