using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalMoney : MonoBehaviour
{
    public GameObject money;
    public static int moneyI = 0;
    public void Start()
    {
        /*if (sqlCreate.getData("loaded")=="1")
        {
            moneyI = int.Parse(sqlCreate.getData("Money"));
            if (GameObject.Find("moneySlot") != null)
            {
                GameObject.Find("moneySlot").SetActive(true);
            }
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        money.GetComponent<Text>().text = moneyI.ToString();
    }
    public static void setMoney(int dbk)
    {
        moneyI += dbk;
        globalVariable.money = moneyI;
        db.addThingToList(14, moneyI.ToString());
    }
    public  void setMoney1(int dbk)
    {
        moneyI = int.Parse(db.readTheData(14));
        moneyI += dbk;
        globalVariable.money = moneyI;
        db.addThingToList(14, moneyI.ToString());
    }
    public void giveMoney(int dbk)
    {
        moneyI = int.Parse(db.readTheData(14));
        Debug.Log(moneyI + "befor");
        moneyI -= dbk;
        globalVariable.money = moneyI;
        Debug.Log(moneyI + "after");
        db.addThingToList(14, moneyI.ToString());
    }
    public static void giveMoney1(int dbk)
    {
        moneyI = int.Parse(db.readTheData(14));
        Debug.Log(moneyI + "befor");
        moneyI -= dbk;
        globalVariable.money = moneyI;
        Debug.Log(moneyI + "after");
        db.addThingToList(14, moneyI.ToString());
    }
}
