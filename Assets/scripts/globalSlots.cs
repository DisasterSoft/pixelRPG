using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalSlots : MonoBehaviour
{
    public GameObject slot1, slot2, slot3, slot4, slot5, slot6;
    public static int slot1I, slot2I, slot3I, slot4I, slot5I, slot6I;
    public static int slot7I, slot8I, slot9I, slot10I, slot11I, slot12I;
    public static string slot1T, slot2T, slot3T, slot4T, slot5T, slot6T,slot7T, slot8T, slot9T, slot10T, slot11T, slot12T;
    public static bool oneSelected=false;
    void Start()
    {
        slot1I =slot2I = slot3I = slot4I = slot5I = slot6I=slot7I =slot8I = slot9I = slot10I = slot11I = slot12I = 0;
    }
    // Update is called once per frame
    void Update()
    {
        slot1.GetComponent<Text>().text = slot1I.ToString();
    }
    public  void setSlot1(int db)
    {
        slot1I = db;
       
    }
    public  void setSlot1Type(string db)
    {
        slot1T = db;
       
    }
    public  void setSlot7DB(int db)
    {
        slot1I = db;
       
    }
    public  void setSlot7Type(int db)
    {
        slot1I = db;
       
    }
    public  void setSlot8DB(int db)
    {
        slot1I = db;
       
    }
    public  void setSlot8Type(int db)
    {
        slot1I = db;
       
    }
}
