using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalQuest : MonoBehaviour
{
    public static int[] quest= new int[10];
    public  bool questFill;
    private void Start()
    {
        if(questFill==false)
        {
            questFill = true;
            for(int i=0;i>12;i++)
            {
                quest[i] = 0;
            }
        }
    }
    public static void setquestActive(int qID)
    {
        quest[qID] = 1;
    }
    public static void setquestComplet(int qID)
    {
        quest[qID] = 2;
    }

}
