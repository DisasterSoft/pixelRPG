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
        if (sqlCreate.getData("loaded")=="1")
        {
            moneyI = int.Parse(sqlCreate.getData("Money"));
            if (GameObject.Find("moneySlot") != null)
            {
                GameObject.Find("moneySlot").SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        money.GetComponent<Text>().text = moneyI.ToString();
    }
    public static void setMoney(int db)
    {
        moneyI += db;
        globalVariable.money = moneyI;
        sqlCreate.setData("Money",moneyI.ToString());
    }
    public  void setMoney1(int db)
    {
        moneyI += db;
        globalVariable.money = moneyI;
        sqlCreate.setData("Money", moneyI.ToString());
    }
    public void giveMoney(int db)
    {

        moneyI -= db;
        globalVariable.money = moneyI;
        sqlCreate.setData("Money", moneyI.ToString());
    }
}
