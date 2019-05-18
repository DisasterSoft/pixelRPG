using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class globalVariable : MonoBehaviour
{
    public static string objectInField;
    public static string playerCoordinate;
    public  string playerCoordinate1;
    public string objectsHelper;
    public static int money;
    public static string Cards;
    public static bool isloaded=false;
    public  bool isloaded1=false;
    public static bool impIsDead = false;
    public  bool impIsDead1 = false;
    public static bool isloadedFromMenu=false;
    public GameObject[] thinkgs;
    public Flowchart flowchart;
    public static  GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public static  void addObjectToList(string objective)
    {
        objectInField = objectInField + objective + ",";
    }
    public static void setPlayerCoord()
    {
        playerCoordinate = player.transform.position.x+";"+player.transform.position.y;
    }
    public static void setMoney(int moneys)
    {
       money=globalMoney.moneyI;
        money += moneys;
    }
    public static void setCard(string card)
    {
        Cards = Cards + card + ",";
    }

    public void Update()
    {
        playerCoordinate1 = playerCoordinate;
        isloaded1 = isloaded;
        impIsDead1 = impIsDead;
        objectsHelper = objectInField;
        if(isloaded)
        {
            thinkgs[4].SetActive(true);
            StartCoroutine(loadThings());
            isloaded = false;
        }
       
           
       
    }

    IEnumerator loadThings()
    {
        yield return new WaitForSeconds(0.5f);
        thinkgs[4].SetActive(false);
        isloaded = false;
        string rendez = globalVariable.objectInField;
        string[] rendez_a = rendez.Split(',');
        for (int i = 0; i < rendez_a.Length; i++)
        {
            if(rendez_a[i]== "impBlue1")
            {
                impIsDead = true;
                flowchart.SendFungusMessage("tavernOpen");
            }
            if (GameObject.Find(rendez_a[i]) != null)
            {
                
                GameObject.Find(rendez_a[i]).SetActive(false);
            }
        }
        
            globalMoney.moneyI = money;
            float x, y;
            string[] coord = playerCoordinate.Split(';');
            x = float.Parse(coord[0]);
            y = float.Parse(coord[1]);
            player.transform.position = new Vector3(x, y);
            thinkgs[0].SetActive(true);
            thinkgs[1].SetActive(true);
            
        if(globalSlots.slot1I>0)
        {
            thinkgs[2].SetActive(true);
        }
        else
        {
            thinkgs[2].SetActive(false);
        }
        if (globalSlots.slot2I>0)
        {
            thinkgs[3].SetActive(true);
        }
        else
        {
            thinkgs[3].SetActive(false);
        }
              if(Cards.Length>0)
             {
                GameObject.Find("Cards").SetActive(true);
             }
        
    }

}
