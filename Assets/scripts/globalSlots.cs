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
        if (globalVariable.isloaded == false)
        {
            slot1I = slot2I = slot3I = slot4I = slot5I = slot6I = slot7I = slot8I = slot9I = slot10I = slot11I = slot12I = 0;
        }
        }
    // Update is called once per frame
    void Update()
    {
        slot1.GetComponent<Text>().text = slot1I.ToString();
        slot1Ib = slot1I;
        slot2.GetComponent<Text>().text = slot2I.ToString();
        slot2Ib = slot2I;
    }
    public  void setSlot1(int db)
    {
        slot1I = db;
       
    }
    public  void setSlot1Type(string db)
    {
        slot1T = db;
       
    }
    public  void setSlot2(int db)
    {
        slot2I = db;
       
    }
    public  void setSlot2Type(string db)
    {
        slot2T = db;
       
    }
    public  void setSlot7DB(int db)
    {
        slot7I = db;
       
    }
    public  void setSlot7Type(int db)
    {
        slot7I = db;
       
    }
    public  void setSlot8DB(int db)
    {
        slot8I = db;
       
    }
    public  void setSlot8Type(string db)
    {
        slot8T = db;
       
    }
    public  void setSlot9DB(int db)
    {
        slot9I = db;
       
    }
    public  void setSlot9Type(string db)
    {
        slot9T = db;
       
    }public  void setSlot10DB(int db)
    {
        slot10I = db;
       
    }
    public  void setSlot10Type(string db)
    {
        slot10T = db;
       
    }public  void setSlot11DB(int db)
    {
        slot11I = db;
       
    }
    public  void setSlot11Type(string db)
    {
        slot11T = db;
       
    }public  void setSlot12DB(int db)
    {
        slot12I = db;
       
    }
    public  void setSlot12Type(string db)
    {
        slot12T = db;
       
    }public  void setSlot13DB(int db)
    {
        slot13I = db;
       
    }
    public  void setSlot13Type(string db)
    {
        slot13T = db;
       
    }
}
