using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVariable : MonoBehaviour
{
    public static string objectInField;
    public static string playerCoordinate;
    public string objectsHelper;
    public static int money;
    public static string Cards;
    public static bool isloaded=false;
    public static bool isloadedFromMenu=false;
    public GameObject[] thinkgs;

    public static  void addObjectToList(string objective)
    {
        objectInField = objectInField + objective + ",";
    }
    public static void setPlayerCoord()
    {
        GameObject player;
        
        player = GameObject.Find("Player");
        playerCoordinate = player.transform.position.x+";"+player.transform.position.y;
    }
    public static void setMoney(int moneys)
    {
       money=globalMoney.moneyI;
        money += moneys;
    }
    public static void setCard(string card)
    {
        Cards = Cards + card + ",";
    }

    public void Update()
    {
        objectsHelper = objectInField;
        if(isloaded)
        {
            StartCoroutine(loadThings());
            isloaded = false;
        }
    }

    IEnumerator loadThings()
    {
        yield return new WaitForSeconds(0.1f);
        isloaded = false;
        string rendez = globalVariable.objectInField;
        string[] rendez_a = rendez.Split(',');
        for (int i = 0; i < rendez_a.Length; i++)
        {
            if (GameObject.Find(rendez_a[i]) != null)
            {
                GameObject.Find(rendez_a[i]).SetActive(false);
            }
        }
            globalMoney.moneyI = money;
            float x, y;
            string[] coord = playerCoordinate.Split(';');
            x = float.Parse(coord[0]);
            y = float.Parse(coord[1]);
            GameObject.Find("Player").transform.position = new Vector3(x, y);
            thinkgs[0].SetActive(true);
            thinkgs[1].SetActive(true);
            thinkgs[2].SetActive(true);
              if(Cards.Length>0)
             {
                GameObject.Find("Cards").SetActive(true);
             }
        
        }

}
