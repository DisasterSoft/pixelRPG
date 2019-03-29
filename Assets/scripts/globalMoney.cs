using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalMoney : MonoBehaviour
{
    public GameObject money;
    public static int moneyI;
    // Start is called before the first frame update
    void Start()
    {
        moneyI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        money.GetComponent<Text>().text = moneyI.ToString();
    }
    public void setMoney(int db)
    {

        moneyI += db;
    }
}
