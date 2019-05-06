using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class langolofa : MonoBehaviour
{
    public Flowchart flowchart;
   
    void OnTriggerEnter2D(Collider2D other)
    {

        flowchart.SendFungusMessage("Mandragora");

    }

    public void giveMoney(int amount)
    {
        if ((globalMoney.moneyI - amount) > -1)
        {
            flowchart.SetBooleanVariable("payOk", true);
            globalMoney.moneyI -= amount;
            StartCoroutine(SavingGame());
        }
    }

    IEnumerator SavingGame()
    {
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("money", globalVariable.money);
        PlayerPrefs.SetString("playerCoord", player_controller.player.transform.position.x+","+ player_controller.player.transform.position.y);
        PlayerPrefs.SetString("objectInfield",globalVariable.objectInField);
        PlayerPrefs.SetString("cards",globalVariable.Cards);
        PlayerPrefs.SetInt("slot1I",globalSlots.slot1I);
        PlayerPrefs.SetInt("slot2I",globalSlots.slot2I);
        PlayerPrefs.SetString("slot1T",globalSlots.slot1T);
        PlayerPrefs.SetString("slot2T",globalSlots.slot2T);
    }
    }
