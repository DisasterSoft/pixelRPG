using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class tavernSpeeker : MonoBehaviour
{
   
    public Flowchart flowchart;
    public int elfCount = 0;
    public int barkeeperCount = 0;
    public int damiCount = 0;
    public int thingCount = 0;
    public int zsigiCount1 = 0;
    public int archerCount = 0;

    public void Start()
    {
        db.addThingToList(1, "1");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.name == "Elf" || this.name=="Elf1" || this.name == "Elf2" || this.name == "Elf3" || this.name == "Elf4" || this.name == "Elf5")
        {
            if (elfCount == 0)
            {
                flowchart.SendFungusMessage("ELF0");
            }
            if (elfCount == 1)
            {
                flowchart.SendFungusMessage("ELF1");
            }
            if (elfCount == 2)
            {
                flowchart.SendFungusMessage("ELF2");
            }
            if (elfCount == 3)
            {
                flowchart.SendFungusMessage("ELF3");
            }
            if (elfCount == 4)
            {
                flowchart.SendFungusMessage("ELF4");
            }
            if (elfCount == 5)
            {
                flowchart.SendFungusMessage("ELF5");
            }
            if (elfCount >5)
            {
               
            }
            elfCount++;
        }
        if(this.name=="BarKeeper")
        {
            if (barkeeperCount == 0)
            {
                flowchart.SendFungusMessage("Barkeeper");
            }
            if (barkeeperCount == 1)
            {
                flowchart.SendFungusMessage("Barkeeper1");
                barkeeperCount--;
            }
           
            barkeeperCount++;
        }
        if (this.name == "Thing")
        {
            if (thingCount == 0)
            {
                flowchart.SendFungusMessage("Thing1");
            }
            if (thingCount == 1)
            {
                thingCount--;
            }
            thingCount++;
        }
        if (this.name == "BlueGirl" || this.name == "BlueGirl1" || this.name == "BlueGirl2")
        {
            flowchart.SendFungusMessage("blueGirl");
        }
        if (this.name == "PurpeeGirl" || this.name == "PurpelGirl1" || this.name == "PurpelGirl2")
        {
            flowchart.SendFungusMessage("PurpleGirl");
        }
        if (this.name == "Rosi")
        {
            flowchart.SendFungusMessage("Rosi");
        }
        if (this.name == "Lyra")
        {
            flowchart.SendFungusMessage("Lyra");
        }
        if (this.name == "Dami")
        {
            if (damiCount == 0)
            {
                flowchart.SendFungusMessage("Dami");
            }
            if(damiCount>0)
            {
                flowchart.SendFungusMessage("Dami1");
                damiCount--;
            }
            damiCount++;
        }
        if (this.name == "Wacy")
        {
            flowchart.SendFungusMessage("Wacy");
        }
        if (this.name == "knight")
        {
            if (zsigiCount1 == 0)
            {
                flowchart.SetIntegerVariable("Money", globalMoney.moneyI);
                flowchart.SendFungusMessage("knight");
            }
        }

        if (this.name == "Archer")
        {
            if (archerCount == 0)
            {
                flowchart.SetIntegerVariable("Money", globalMoney.moneyI);
                flowchart.SendFungusMessage("Archer");
            }
        }
        if (this.name == "assasin")
        {
           
               
                flowchart.SendFungusMessage("assasin");
           
        }
        if (this.name == "exit")
        {


            flowchart.SendFungusMessage("exit");
            int givingMoney = globalMoney.moneyI;
            globalMoney.setMoney(givingMoney);
            db.addThingToList(17, "5");
            globalVariable.setPlayerCoordToSpec(-17.02f, 3.44f);
        }

    }
    public void knighCountInc()
    {
        this.zsigiCount1++;
        globalVariable.addObjectToList("knight");
    }
    public void archerCountInc()
    {
       this.archerCount++;
        globalVariable.addObjectToList("Archer");
    }
    public void addAssasin()
    {
        globalVariable.addObjectToList("assasin");
        globalVariable.setPlayerCoord();
        //globalVariable.setCard("c1");
    }
   
   /* IEnumerator loadSceene()
    {
        yield return new WaitForSeconds(0.1f);
       

    }*/


}
