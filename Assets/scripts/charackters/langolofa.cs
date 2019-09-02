using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class langolofa : MonoBehaviour
{
    public Flowchart flowchart;
    public static int count = 0;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (count == 0)
        {
            flowchart.SendFungusMessage("Mandragora");
        }
        if (count == 1)
        {
            flowchart.SendFungusMessage("Mandragora1");
            count--;
        }

        count++;

    }

    public void giveMoney(int amount)
    {
        if ((globalMoney.moneyI - amount) > -1)
        {
            flowchart.SetBooleanVariable("payOk", true);
            globalMoney.moneyI -= amount;
            globalVariable.setPlayerCoord();
            db.addThingToList(14, globalMoney.moneyI.ToString());
            db.saveGame();
        }
    }

   
    }
