using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goingOut : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.name == "goingOut")
        {
            cameraScriptMap.goindOut = true;
        }
    }
}
