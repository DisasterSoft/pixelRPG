using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalSlots : MonoBehaviour
{
    public GameObject slot1, slot2, slot3, slot4, slot5, slot6;
    public static int slot1I, slot2I, slot3I, slot4I, slot5I, slot6I;
    public static int slot1x, slot1y, slot2x, slot2y, slot3x, slot3y, slot4x, slot4y, slot5x, slot5y, slot6x, slot6y;
    public  int slot1Ib, slot2Ib, slot3Ib, slot4Ib, slot5Ib, slot6Ib;
    public static int slot7I, slot8I, slot9I, slot10I, slot11I, slot12I, slot13I;
    public static string slot1T, slot2T, slot3T, slot4T, slot5T, slot6T,slot7T, slot8T, slot9T, slot10T, slot11T, slot12T, slot13T;
    public static bool oneSelected=false;
    public static bool twoSelected=false;
    public static bool threeSelected=false;
    public static bool fourSelected=false;
    public static bool fiveSelected=false;
    public static bool sixSelected=false;
    void Start()
    {
        if (db.readTheData(1) == "1")
         {

             slot1I = int.Parse(db.readTheData(2));
             slot2I = int.Parse(db.readTheData(3));
             slot3I = int.Parse(db.readTheData(4));
             slot4I = int.Parse(db.readTheData(5));
             slot5I = int.Parse(db.readTheData(6));
             slot6I = int.Parse(db.readTheData(7));
             slot1T = db.readTheData(8);
             slot2T = db.readTheData(9);
             slot3T = db.readTheData(10);
             slot4T = db.readTheData(11);
             slot5T = db.readTheData(12);
             slot6T = db.readTheData(13); 
             slot7I = slot8I = slot9I = slot10I = slot11I = slot12I = 0;
         }
         else
         {
             slot1I = slot2I = slot4I = slot5I = slot5I = slot6I= slot7I = slot8I = slot9I = slot10I = slot11I = slot12I = 0;
         }
       
    }
    // Update is called once per frame
    void Update()
    {
        slot1.GetComponent<Text>().text = slot1I.ToString();
        slot1Ib = slot1I;
        slot2.GetComponent<Text>().text = slot2I.ToString();
        slot2Ib = slot2I;
        slot3.GetComponent<Text>().text = slot3I.ToString();
        slot3Ib = slot3I;
    }
    public static void setSlot1(int dbk)
    {
        slot1I = dbk;
       db.addThingToList(2, dbk.ToString());
       
    }
    public static void setSlot1Type(string dbk)
    {
        slot1T = dbk;
        db.addThingToList(8, dbk);

    }
    public static void setSlot2(int dbk)
    {
        slot2I = dbk;
        db.addThingToList(3, dbk.ToString());

    }
    public static void setSlot2Type(string dbk)
    {
        slot2T = dbk;
        db.addThingToList(9, dbk);

    }
    public static void setSlot3(int dbk)
    {
        slot3I = dbk;
       db.addThingToList(4, dbk.ToString());

    }
    public static void setSlot3Type(string dbk)
    {
        slot3T = dbk;
       db.addThingToList(10, dbk);

    }
    public static void setSlot4(int dbk)
    {
        slot3I = dbk;
        //db.addThingToList("slot4I", dbk.ToString());

    }
    public static  void setSlot4Type(string dbk)
    {
        slot3T = dbk;
     //   db.addThingToList("slot4T", dbk);

    }
    public static  void setSlot5(int dbk)
    {
        slot3I = dbk;
       // db.addThingToList("slot5I", dbk.ToString());

    }
    public static  void setSlot5Type(string dbk)
    {
        slot3T = dbk;
       // db.addThingToList("slot5T", dbk);

    }
    public static void setSlot6(int dbk)
    {
        slot3I = dbk;
       // db.addThingToList("slot6I", dbk.ToString());

    }
    public static void setSlot6Type(string dbk)
    {
        slot3T = dbk;
      //  db.addThingToList("slot6T", dbk);

    }
    public  void setSlot7dbk(int dbk)
    {
        slot7I = dbk;
       
    }
    public  void setSlot7Type(int dbk)
    {
        slot7I = dbk;
       
    }
    public  void setSlot8dbk(int dbk)
    {
        slot8I = dbk;
       
    }
    public  void setSlot8Type(string dbk)
    {
        slot8T = dbk;
       
    }
    public  void setSlot9dbk(int dbk)
    {
        slot9I = dbk;
       
    }
    public  void setSlot9Type(string dbk)
    {
        slot9T = dbk;
       
    }public  void setSlot10dbk(int dbk)
    {
        slot10I = dbk;
       
    }
    public  void setSlot10Type(string dbk)
    {
        slot10T = dbk;
       
    }public  void setSlot11dbk(int dbk)
    {
        slot11I = dbk;
       
    }
    public  void setSlot11Type(string dbk)
    {
        slot11T = dbk;
       
    }public  void setSlot12dbk(int dbk)
    {
        slot12I = dbk;
       
    }
    public  void setSlot12Type(string dbk)
    {
        slot12T = dbk;
       
    }public  void setSlot13dbk(int dbk)
    {
        slot13I = dbk;
       
    }
    public  void setSlot13Type(string dbk)
    {
        slot13T = dbk;
       
    }
}
