using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DumbLuck.Utilities;
using System;

namespace DumbLuck
{

    /*
     * Debug osztály, különböző segítő funkciókkal, amivel gyorsan lehet létrehozni gombokat, szövegeket, stb...
     */
    public static class DebugHelper
    {
        // Létrehoz egy Gombot a world-ben
        public static World_Sprite Button(Transform parent, Vector3 localPosition, string text, System.Action ClickFunc, int fontSize = 30,
                                          float paddingX = 5, float paddingY = 5)
        {
            return World_Sprite.CreateDebugButton(parent, localPosition, text, ClickFunc, fontSize, paddingX, paddingY);
        }

        // Létrehoz egy Gombot az UI felületen
        public static UI_Sprite ButtonUI(Vector2 anchoredPosition, string text, Action ClickFunc)
        {
            return UI_Sprite.CreateDebugButton(anchoredPosition, text, ClickFunc);
        }

        // Létrehoz egy World Text objektumot a world-beli pozíción
        public static void Text(string text, Vector3 localPosition = default(Vector3), Transform parent = null, int fontSize = 40,
                                Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, 
                                int sortingOrder = UtilsClass.sortingOrderDefault)
        {
            UtilsClass.CreateWorldText(text, parent, localPosition, fontSize, color, textAnchor, textAlignment, sortingOrder);
        }
    }
}