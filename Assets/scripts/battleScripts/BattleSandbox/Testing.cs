﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Testing : MonoBehaviour
{
    void Start()
    {
       // DamagePopup.Create(Vector3.zero, 300);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DamagePopup.Create(UtilsClass.GetMouseWorldPosition(), 100);
        }
    }
}