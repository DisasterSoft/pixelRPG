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
        string[] seged = globalVariable.Cards.Split(',');
       
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
        }
    }
    public void onOneCardClick()
    {
       
                oneCard.SetActive(false);
                
    }
    public void closeCardPanel()
    {
       
        CardPanel.SetActive(false);
        joystick.SetActive(true);

    }
}
