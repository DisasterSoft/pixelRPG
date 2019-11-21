using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class dancer1Script : MonoBehaviour
{
    public int dancer2_ounter = 0;
    public Flowchart flowchart;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.name == "dancers1")
        {
            globalVariable.addObjectToList("dancers1");
            flowchart.SendFungusMessage("Dancer1");
            globalVariable.setCard("1");
        }
        if (this.name == "dancers2")
        {
            globalVariable.addObjectToList("dancers2");
            flowchart.SendFungusMessage("Dancer2");
                globalVariable.setCard("3");
           
        }
    }
}
