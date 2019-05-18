using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTavernMusic : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        cameraScriptMap.playTavernmusic();
        GameObject.Find("tavern music").SetActive(false);
    }

    }
