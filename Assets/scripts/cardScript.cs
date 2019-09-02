using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardScript : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[15];
    public GameObject joystick, CardPanel, oneCard, cardImage;
    public GameObject[] cards = new GameObject [15];
   public void onCardClick()
    {
       joystick.SetActive(false);
       CardPanel.SetActive(true);
        string[] seged = db.readTheData(15).Split(',');
        Debug.Log(db.readTheData(15));
        for(int i=0;i<seged.Length;i++)
        {
           
            if (seged[i]!="")
            {
                cards[i].SetActive(true);
            }
            else
            {
                cards[i].SetActive(false);
            }
        }
    }
    public void onSpecialCardClick(string card)
    {
       
        switch (card)
        {
            case "c1":
                oneCard.SetActive(true);
                cardImage.GetComponent<Image>().sprite=sprite[0];
                //cardImage.GetComponent<Image>().type="Simple";
                break;
              case "c2":
                oneCard.SetActive(true);
                cardImage.GetComponent<Image>().sprite=sprite[1];
                //cardImage.GetComponent<Image>().type="Simple";
                break;
        }
    }
    public void onOneCardClick()
    {
       
                oneCard.SetActive(false);
                
    }
    public void addCard(string card)
    {
        Debug.Log("hozzáadva " + card);
        string seged = db.readTheData(15);
        seged = seged + card + ",";
        db.addThingToList(15, seged);

    }
    public void closeCardPanel()
    {
       
        CardPanel.SetActive(false);
        joystick.SetActive(true);

    }
}
