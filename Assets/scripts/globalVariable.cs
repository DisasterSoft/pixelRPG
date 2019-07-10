using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class globalVariable : MonoBehaviour
{
    public static string objectInField;
    public static string playerCoordinate="";
    public  string playerCoordinate1;
    public string objectsHelper;
    public static int money;
    public static int  loadCount=0;
    public int  loadCountnonStat=0;
    public static string Cards;
    public  string CardsnonStat;
    public static bool isloaded=false;
    public  bool isloaded1=false;
    public static bool impIsDead = false;
    public  bool impIsDead1 = false;
    public static bool isloadedFromMenu=false;
    public GameObject[] thinkgs;
    public GameObject[] miscMenu;
    public Flowchart flowchart;
    public static GameObject player;
    public GameObject nonStaticplayer;

    private void Start()
    {
        player = nonStaticplayer;
        if (sqlCreate.getData("loaded") == "1")
        {
            objectInField = sqlCreate.getData("ObjectHelper");
            Cards= sqlCreate.getData("Cards");
            loadCount = int.Parse(sqlCreate.getData("loadCount"));
        }
        else
        {
            if(loadCount==0)
            {
             // sqlCreate.newStart();
            }
        }
        if (loadCount==0)
        {
            
            miscMenu[0].SetActive(false); 
            miscMenu[1].SetActive(false); 
            miscMenu[2].SetActive(false); 
            miscMenu[3].SetActive(false); 
            miscMenu[7].SetActive(false); 
            miscMenu[8].SetActive(false); 
            
        }
        if (loadCount == 1)
        {
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(false);
            miscMenu[7].SetActive(false);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 2)
        {
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(false);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
       
    }
    public static  void addObjectToList(string objective)
    {
        objectInField = objectInField + objective + ",";
        sqlCreate.setData("ObjectHelper", objectInField);
    }
    public  void addObjectToListNonstatic(string objective)
    {
        objectInField = objectInField + objective + ",";
        sqlCreate.setData("ObjectHelper", objectInField);
    }
    public static void setPlayerCoord()
    {
        playerCoordinate = player.transform.position.x+";"+player.transform.position.y;
        sqlCreate.setData("Coordinate", playerCoordinate);
    }
    public static void setMoney(int moneys)
    {
       money=globalMoney.moneyI;
       money += moneys;
       sqlCreate.setData("Money", money.ToString());
    }
    public static void setCard(string card)
    {
        Cards = Cards + card + ",";
        sqlCreate.setData("Cards", Cards);
    }
   
    public void Update()
    {
        playerCoordinate1 = playerCoordinate;
        isloaded1 = isloaded;
        impIsDead1 = impIsDead;
        objectsHelper = objectInField;
        CardsnonStat = Cards;
        loadCountnonStat =loadCount;
        if (sqlCreate.getData("loaded") == "1")
        {
            loadCount++;
            sqlCreate.setData("loadCount", loadCount.ToString());
            thinkgs[4].SetActive(true);
            StartCoroutine(loadThings());
            isloaded = false;
            sqlCreate.setData("loaded", "0");
        }
       
           
       
    }

    IEnumerator loadThings()
    {
        thinkgs[4].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        string rendez = sqlCreate.getData("ObjectHelper");
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
        
            globalMoney.moneyI = int.Parse(sqlCreate.getData("Money"));
        Debug.Log(money + "isLoaded");
            float x, y;
            playerCoordinate = sqlCreate.getData("Coordinate");
            string[] coord = playerCoordinate.Split(';');
            x = float.Parse(coord[0]);
            y = float.Parse(coord[1]);
            player.transform.position = new Vector3(x, y);
             Debug.Log(x+"coord"+y + "isLoaded");
            thinkgs[0].SetActive(true);
            thinkgs[1].SetActive(true);
            
        if(globalSlots.slot1I>0)
        {
            miscMenu[0].SetActive(true);
            Debug.Log("slot 1isLoaded");
            thinkgs[2].SetActive(true);
        }
        else
        {
            Debug.Log("slot 1unisLoaded");
            miscMenu[0].SetActive(true);
            thinkgs[2].SetActive(false);
        }
        if (globalSlots.slot2I>0)
        {
            Debug.Log("slot 2isLoaded");
            miscMenu[0].SetActive(true);
            thinkgs[3].SetActive(true);
        }
        else
        {
            Debug.Log("slot 2isUnLoaded");
            thinkgs[3].SetActive(false);
        }
        if (globalSlots.slot3I > 0)
        {
            miscMenu[0].SetActive(true);
            Debug.Log("slot 3isLoaded");
            thinkgs[5].SetActive(true);
        }
        else
        {
            miscMenu[0].SetActive(true);
            Debug.Log("slot 3isUnLoaded");
            thinkgs[5].SetActive(false);
        }
         if(Cards.Length>0)
            {
            miscMenu[7].SetActive(true);
            Debug.Log("card isLoaded");
            }
        

    }
    public void addKnight1(int db)
    {
        globalSlots.slot1I += db;
        sqlCreate.addSlot(1, db, "k");
    }
    public void addArcher1(int db)
    {
        globalSlots.slot2I += db;
        sqlCreate.addSlot(2, db, "ar");
    }
    public void addAssasin1(int db)
    {
        globalSlots.slot3I += db;
        sqlCreate.addSlot(3, db, "as");
    }
    

}
