using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class impScript1 : MonoBehaviour
{
  
   
    public Flowchart flowchart;
    protected float min = -8.5f;
    protected float min1 = -8.5f;
    protected float min2 = 16f;
    public void Update()
    {
        if (GameObject.Find("impBlue1") != null)
        {

           
            if (GameObject.Find("impBlue1").transform.position.x > min)
            {
               
                GameObject.Find("impBlue1").transform.Translate(-Time.deltaTime, 0, 0);
            }
            else
            {
                GameObject.Find("impBlue1").transform.Translate(Time.deltaTime, 0, 0);
            }
            if (Mathf.Round(GameObject.Find("impBlue1").transform.position.x) == Mathf.Round(min1))
            {
                min = min2;
            }
            if (Mathf.Round(GameObject.Find("impBlue1").transform.position.x) == Mathf.Round(min2))
            {
                min = min1;
            }

            



        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        min = GameObject.Find("impBlue1").transform.position.x;
        cameraScriptMap.playBattlemusic();
        if(globalSlots.slot2I<1)
        {
            flowchart.SendFungusMessage("needArcher");
        }
        else
        {
            flowchart.SendFungusMessage("imp1Attack");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        cameraScriptMap.stopBattlemusic();
        min = min1;
    }
   public void attackImp()
    {

        globalVariable.addObjectToList("impBlue1");
        globalVariable.setPlayerCoord();
        globalSlots.slot7I = 40;
        globalSlots.slot7T = "BImp";
        globalSlots.slot8I = 35;
        globalSlots.slot8T = "RImp";
        globalSlots.slot9I = 20;
        globalSlots.slot9T = "BImp";
    }
    }
