using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    // Asset-ek hívása kódon keresztül, nekem egyszerűbb mint egyesével összekötögetni a különböző monobehaviour-okat Unity-ban
    // Lényegében csak egy könyvtár a különböző asset-ek számára

    // Szimplán csak i, mivel nem lesz egy túl nagy Class és mindig kiírni, hogy GameObject.Instance hosszú, és más esetekben még
    // össze is zavarhat
    private static GameAssets _i;
        
    public static GameAssets i
    {
        get
        {
            if (_i == null)
            {
                _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }
            return _i;
        }
    }

    public Transform damagePopupPrefab;
}
