using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wishps : MonoBehaviour
{
    
    
    void OnTriggerExit2D(Collider2D other)
    {

        GameObject.Find(this.name).SetActive(false);

    }
}
