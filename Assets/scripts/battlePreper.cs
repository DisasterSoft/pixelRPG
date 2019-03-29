using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlePreper : MonoBehaviour
{
    public static string[][] gameModel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                gameModel[i][j] = "0";
                if (globalSlots.slot1I > 0 && i == 0 && j == 7)
                {
                    gameModel[i][j] = globalSlots.slot1T;
                }
                if (globalSlots.slot2I > 0 && i == 2 && j == 7)
                {
                    gameModel[i][j] = globalSlots.slot2T;
                }
                if (globalSlots.slot3I > 0 && i == 3 && j == 7)
                {
                    gameModel[i][j] = globalSlots.slot3T;
                }
                if (globalSlots.slot4I > 0 && i == 4 && j == 7)
                {
                    gameModel[i][j] = globalSlots.slot4T;
                }
                if (globalSlots.slot5I > 0 && i == 5 && j == 7)
                {
                    gameModel[i][j] = globalSlots.slot5T;
                }
                if (globalSlots.slot6I > 0 && i == 6 && j == 7)
                {
                    gameModel[i][j] = globalSlots.slot6T;
                }
            }
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
