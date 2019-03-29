using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class tileScript : MonoBehaviour
{

    public static string[,] gameModel = new string[8, 8];
    public GameObject[] tiles;
    public GameObject[] slots;
    public GameObject[] enemys;
    public GameObject obj;
    public static string slot1Coord;
    public static string[] tileS = new string[64];
    public string[] tileSLocal = new string[64];
    public Material[] mat;

    // Start is called before the first frame update

    void Start()
    {
        /*segítség*/
        globalSlots.slot1I = 40;
        globalSlots.slot1T = "k";
        globalSlots.slot8I = 7;
        globalSlots.slot8T = "w";
        globalSlots.slot9I = 5;
        globalSlots.slot9T = "w";
        for (int i = 0; i < 64; i++)
        {
            tileS[i] = "0";
        }
        tileSLocal = tileS;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                gameModel[i, j] = "0";
                if (globalSlots.slot1I > 0 && i == 0 && j == 7)
                {
                    gameModel[i, j] = globalSlots.slot1T;
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
                }
                if (globalSlots.slot9I > 0 && i == 2 && j == 0)
                {
                    gameModel[i, j] = globalSlots.slot9T;
                }
               
            }
        }
        kiirMap();


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 63; i++)
        {
            if (tileS[i] == "1")
            {

                tiles[i].GetComponent<Renderer>().sharedMaterial = mat[1];
            }
            else
            {
                tiles[i].GetComponent<Renderer>().sharedMaterial = mat[0];
            }
        }

    }
   public static void kiirMap()
    {
        string kiir = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                kiir = kiir + gameModel[i, j] + ",";
        if (j % 8 == 7)
        {

            kiir = kiir + "\n";
        }
    }
}
Debug.Log(kiir);
    }

    public static void ujraRajzol(int poz)
    {
        int a = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tileS[((i * 8) + j)] = "0";
                if (a == poz)
                {
                    gameModel[i, j] = "k";
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
                tileS[((i * 8) + j)] = "0";
                if (a == poz)
                {
                    gameModel[i, j] = "0";
                }
                a++;

            }
        }
    }


}
