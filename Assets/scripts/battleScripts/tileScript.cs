using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Fungus;

[System.Serializable]
public class tileScript : MonoBehaviour
{

    public static string[,] gameModel = new string[8, 8];
    public static GameObject[] tiles=new GameObject[64];
    public GameObject[] slots;
    public GameObject[] enemys;
    public GameObject obj;
    public Flowchart flowchart;
    public static string slot1Coord,slot2Coord,slot3Coord,slot4Coord,slot5Coord,slot6Coord,slot7Coord,slot8Coord,slot9Coord,slot10Coord,slot11Coord,slot12Coord,slot13Coord,slot14Coord;
    public static string[] tileS = new string[64];
    public string[] tileSLocal = new string[64];
    public Material[] mat;
    public static int round;
    public static bool win=false;
    public static bool lose=false;
    // Start is called before the first frame update

    void Start()
    {
        /*segítség*/
        for (int i = 0; i < 64; i++)
        {
            tiles[i] = GameObject.Find("simpleTile" + i);
        }

        //globalSlots.slot1I = 40;
        globalSlots.slot1T = "k";
      // globalSlots.slot8I = 7;
        globalSlots.slot8T = "w1";
       //globalSlots.slot9I = 5;
        globalSlots.slot9T = "w2";
        round = 1;
       // Debug.Log("slot1 " + globalSlots.slot1I);
        for (int i = 0; i < 64; i++)
        {
            tileS[i] = "0";
        }
        //tileSLocal = tileS;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                gameModel[i, j] = "0";
                if (globalSlots.slot1I > 0)
                {
                    if (i == 0 && j == 7)
                    {
                        gameModel[i, j] = globalSlots.slot1T;
                        slot1Coord = "0,7";
                    }
                }
                else
                {
                    gameModel[i, j] = "0";
                    slots[0].SetActive(false);
                    flowchart.SendFungusMessage("youLose");
                }
                if (globalSlots.slot2I > 0 && i == 2 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot2T;
                }
                if (globalSlots.slot3I > 0 && i == 3 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot3T;
                }
                if (globalSlots.slot4I > 0 && i == 4 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot4T;
                }
                if (globalSlots.slot5I > 0 && i == 5 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot5T;
                }
                if (globalSlots.slot6I > 0 && i == 6 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot6T;
                }
                if (globalSlots.slot7I > 0 && i == 7 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot7T;
                }
                if (globalSlots.slot8I > 0 && i == 0 && j == 0)
                {
                    gameModel[i, j] = globalSlots.slot8T;
                    slot8Coord = "0,0";
                }
                if (globalSlots.slot9I > 0 && i == 2 && j == 0)
                {
                    gameModel[i, j] = globalSlots.slot9T;
                    slot9Coord = "2,0";
                }
               
            }
        }
        Debug.Log("start");
        //kiirMap();
    }

    // Update is called once per frame
    void Update()
    {
       if(lose)
        {
            flowchart.SendFungusMessage("youLose");
        }
            for (int i = 0; i < 64; i++)
            {

                if (tileS[i] == "0")
                {

                    tiles[i].GetComponent<Renderer>().sharedMaterial = mat[0];
                }
                if (tileS[i] == "1")
                {

                    tiles[i].GetComponent<Renderer>().sharedMaterial = mat[1];
                }
                if (tileS[i] == "2")
                {

                    tiles[i].GetComponent<Renderer>().sharedMaterial = mat[0];
                }
                if (tileS[i] == "aa")
                {

                    tiles[i].GetComponent<Renderer>().sharedMaterial = mat[2];
                }
               
            
        }
            if(win)
        {
            win = false;
            flowchart.SendFungusMessage("youWin");
            globalVariable.isloaded = true;
           
        }
    }
   public static void kiirMap()
    {
        string kiir = "";
        string kiir2 = "";
        int k = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                kiir = kiir + gameModel[i, j] + ",";
                kiir2 = kiir2 + tileS[k] + ",";
        if (j % 8 == 7)
        {

            kiir = kiir + "\n";
            kiir2 = kiir2 + "\n";
        }
                k++;
        
    }
}
Debug.Log(kiir+" slot1coord "+slot1Coord);
Debug.Log(kiir2);
    }

    public static void ujraRajzol(int poz)
    {
        int a = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (a == poz)
                {
                    gameModel[i, j] = "k";
                    tileS[((i * 8) + j)] = "2";
                    slot1Coord = i+","+j;
                   
                }
                a++;

            }
        }
    }
    public static void ujraRajzolRegi(int poz)
    {
        int a = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                
                if (gameModel[i, j] == "1")
                {
                    tileS[((i * 8) + j)] = "0";
                    gameModel[i, j] = "0";
                }
                if (a == poz)
                {
                    tileS[((i * 8) + j)] = "0";
                    gameModel[i, j] = "0";
                }
                a++;

            }
        }
    }


}
