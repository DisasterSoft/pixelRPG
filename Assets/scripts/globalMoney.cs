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
        if(globalVariable.isloaded)
        {
            moneyI = globalVariable.money;
        }
    }
    // Update is called once per frame
    void Update()
    {
        money.GetComponent<Text>().text = moneyI.ToString();
    }
    public void setMoney(int db)
    {

        moneyI += db;
        globalVariable.money = moneyI;
    }
    public void giveMoney(int db)
    {

        moneyI -= db;
        globalVariable.money = moneyI;
    }
}
