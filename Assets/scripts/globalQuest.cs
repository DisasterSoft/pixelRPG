using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalQuest : MonoBehaviour
{
    public  void setquestActive(int qID)
    {
        string quest = db.readTheData(19);
        string[] quest_a = quest.Split(',');
        string returnQuest="";
        for(int i=0; i<quest_a.Length;i++)
        {
            if(i==qID)
            {
                returnQuest = returnQuest + "1,";
            }
            else
            {
                returnQuest = returnQuest + quest_a[i] + ",";
            }
        }
        db.addThingToList(19, returnQuest);
    }

    public  void setquestComplet(int qID)
    {
        string quest = db.readTheData(19);
        string[] quest_a = quest.Split(',');
        string returnQuest = "";
        for (int i = 0; i < quest_a.Length; i++)
        {
            if (i == qID)
            {
                returnQuest = returnQuest + "2,";
            }
            else
            {
                returnQuest = returnQuest + quest_a[i] + ",";
            }
        }
        db.addThingToList(19, returnQuest);
    }
    public void startQuest3()
    {
        tavernSpeeker.thingCount_st = 1;
    }

}
