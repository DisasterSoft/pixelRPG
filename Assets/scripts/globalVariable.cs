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
        loadCount = int.Parse(db.readTheData(17));
        if (db.readTheData(1) == "1")//loaded
        {
            objectInField = db.readTheData(18);//objecthelper
            Cards= db.readTheData(15);//cards
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
            StartCoroutine(eraseLoadPanel());
            thinkgs[4].SetActive(true);
            miscMenu[0].SetActive(false); 
            miscMenu[1].SetActive(false); 
            miscMenu[2].SetActive(false); 
            miscMenu[3].SetActive(false); 
            miscMenu[7].SetActive(false); 
            miscMenu[8].SetActive(false); 
            
        }
        if (loadCount == 1)
        {
            cameraScriptMap.playOutStartPos();
            thinkgs[4].SetActive(true);
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(false);
            miscMenu[3].SetActive(false);
            miscMenu[7].SetActive(false);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 2)
        {
            cameraScriptMap.playOutStartPos();
            thinkgs[4].SetActive(true);
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(false);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 3)
        {
            thinkgs[4].SetActive(true);
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(false);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 4)
        {
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(true);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 5)
        {
            thinkgs[4].SetActive(true);
            db.addThingToList(1, "1");
            cameraScriptMap.playRaisOftheDeath();
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(true);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 6)
        {
            thinkgs[4].SetActive(true);
            cameraScriptMap.playRaisOftheDeath();
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(true);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
        if (loadCount == 7)
        {
            thinkgs[4].SetActive(true);
            cameraScriptMap.playRaisOftheDeath();
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(true);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }
        if (loadCount ==10)
        {
            thinkgs[4].SetActive(true);
            cameraScriptMap.playRaisOftheDeath();
            miscMenu[0].SetActive(true);
            miscMenu[1].SetActive(true);
            miscMenu[2].SetActive(true);
            miscMenu[3].SetActive(true);
            miscMenu[4].SetActive(true);
            miscMenu[7].SetActive(true);
            miscMenu[8].SetActive(true);
        }

    }
    public static  void addObjectToList(string objective)
    {
        string theObjects = db.readTheData(18);
        string[] objects_array = theObjects.Split(',');
        bool megvan = true;
        for (int i = 0; i < objects_array.Length; i++)
        {
            if (objects_array[i] == objective)
            {
                megvan = false;
                break;
            }
        }
        if (megvan)
        {
            objectInField = objectInField + objective + ",";
            db.addObjectToList(objective);
        }
    }
    public  void addObjectToListNonstatic(string objective)
    {
        objectInField = objectInField + objective + ",";
        db.addObjectToList(objective);
    }
    public static void setPlayerCoord()
    {
        playerCoordinate = player.transform.position.x+"&"+player.transform.position.y;
        db.addThingToList(16, playerCoordinate);
    }
    public void setPlayerCoordnonST()
    {
        playerCoordinate = player.transform.position.x+"&"+player.transform.position.y;
        db.addThingToList(16, playerCoordinate);
    }  
    public static void setPlayerCoordToSpec(float x, float y)
    {
        playerCoordinate = x+"&"+y;
        db.addThingToList(16, playerCoordinate);
    }
    public void setPlayerCoordToSpecNOnST(float x, float y)
    {
        playerCoordinate = x+"&"+y;
        db.addThingToList(16, playerCoordinate);
    }
    
    public static void setMoney(int moneys)
    {
       money=int.Parse(db.readTheData(14));
       money += moneys;
       db.addThingToList(14, money.ToString());
    }
    public static void setCard(string card)
    {
        string theCards=db.readTheData(15);
        string[] cards_array = theCards.Split(',');
        bool megvan = true;
        for (int i = 0;i<cards_array.Length;i++)
        {
            if(cards_array[i]==card)
            {
                megvan = false;
                break;
            }
        }
            if (megvan) {
                Cards = db.readTheData(15) + card + ",";
                db.addThingToList(15, Cards); }
    }
   
    public void Update()
    {
        playerCoordinate1 = playerCoordinate;
        isloaded1 = isloaded;
        impIsDead1 = impIsDead;
        objectsHelper = objectInField;
        CardsnonStat = Cards;
        loadCountnonStat =loadCount;
        if (db.readTheData(1) == "1")
        {
            loadCount++;
            db.addThingToList(17, loadCount.ToString());
            //thinkgs[4].SetActive(true);
            StartCoroutine(loadThings());
            isloaded = false;
            db.addThingToList(1, "0");
        }
       
           
       
    }

    IEnumerator eraseLoadPanel()
    {
        yield return new WaitForSeconds(1);
        thinkgs[4].SetActive(false);
    }

        IEnumerator loadThings()
    {
        
        yield return new WaitForSeconds(0.5f);
        string rendez = db.readTheData(18);
        string[] rendez_a = rendez.Split(',');
        for (int i = 0; i < rendez_a.Length; i++)
        {
            if(rendez_a[i]== "impBlue1" && int.Parse(db.readTheData(17))<4)
            {
                impIsDead = true;
                flowchart.SendFungusMessage("tavernOpen");
            }
            if (rendez_a[i]== "zombie1")
            {
                flowchart.SendFungusMessage("tavernOpen");
            }
            if (GameObject.Find(rendez_a[i]) != null)
            {
                
                GameObject.Find(rendez_a[i]).SetActive(false);
            }
        }
        
        globalMoney.moneyI = int.Parse(db.readTheData(14));
        Debug.Log(money + "isLoaded");
            float x, y;
            playerCoordinate = db.readTheData(16);
            //playerCoordinate = playerCoordinate;
            string[] coord = playerCoordinate.Split('&');
            x = float.Parse(coord[0]);
            y = float.Parse(coord[1]);
            player.transform.position = new Vector3(x, y);
             Debug.Log(x+"coord"+y + "isLoaded");
            thinkgs[0].SetActive(true);
            thinkgs[1].SetActive(true);
            
        if(int.Parse(db.readTheData(2))>0)
        {
            globalSlots.setSlot1(int.Parse(db.readTheData(2)));
            globalSlots.setSlot1Type(db.readTheData(8));
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
        if (int.Parse(db.readTheData(3)) > 0)
        {
            globalSlots.setSlot2(int.Parse(db.readTheData(3)));
            globalSlots.setSlot2Type(db.readTheData(9));
            Debug.Log("slot 2isLoaded");
            miscMenu[1].SetActive(true);
            thinkgs[3].SetActive(true);
        }
        else
        {
            Debug.Log("slot 2isUnLoaded");
            miscMenu[2].SetActive(false);
            thinkgs[3].SetActive(false);
        }
        if (int.Parse(db.readTheData(4)) > 0)
        {
            globalSlots.setSlot3(int.Parse(db.readTheData(4)));
            globalSlots.setSlot3Type(db.readTheData(10));
            miscMenu[3].SetActive(true);
            Debug.Log("slot 3isLoaded");
            thinkgs[5].SetActive(true);
        }
        else
        {
            miscMenu[3].SetActive(false);
            Debug.Log("slot 3isUnLoaded");
            thinkgs[5].SetActive(false);
        }
        Cards = db.readTheData(15);
         if(Cards.Length>1)
            {
            miscMenu[7].SetActive(true);
            Debug.Log("card isLoaded");
            }

        thinkgs[4].SetActive(false);
    }
    public void addKnight1(int dbk)
    {
        globalSlots.slot1I += dbk;
        globalSlots.slot1T += "k";
        int slot1 = int.Parse(db.readTheData(2)) + dbk;
        db.addThingToList(2, slot1.ToString());
        db.addThingToList(8, "k");


    }
    public void addArcher1(int dbk)
    {
        globalSlots.slot2I += dbk;
        int slot1 = int.Parse(db.readTheData(3)) + dbk;
        db.addThingToList(3, slot1.ToString());
        db.addThingToList(9, "ar");
    }
    public void addAssasin1(int dbk)
    {
        globalSlots.slot3I += dbk;
        int slot1 = int.Parse(db.readTheData(4)) + dbk;
        db.addThingToList(4, slot1.ToString());
        db.addThingToList(10, "as");  
    }
    

}
