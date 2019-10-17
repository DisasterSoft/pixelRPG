using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    /*
     * Különböző, válogatott, több helyen is használható funkciók gyűjtőhelye ez a script.
     * Idővel bővülni fog a tárház és az egyszerűbb használhatóság végett namespace-be foglaltam.
     */

    public static class UtilsClass
    {
        public const int sortingOrderDefault = 5000;

        // Szöveg létrehozása a world-ben
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3),
                                               int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, 
                                               TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
        {
            if (color == null) color = Color.white;
            {
                return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
            }
        }

        // Szöveg létrehozása a world-ben
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color,
                                               TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

            return textMesh;
        }

        //Egér pozíciója a world-ben, z = 0f értékkel
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;

            return vec;
        }

        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }

        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);

            return worldPosition;
        }

        // Visszaad 00-FF, a value: 0->255
        public static string Dec_to_Hex(int value)
        {
            return value.ToString("X2");
        }

        // Visszaad 0-255
        public static int Hex_to_Dec(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        // Visszaad egy hex string-et egy 0 és 1 közötti számra alapozva
        public static string Dec01_to_Hex(float value)
        {
            return Dec_to_Hex((int)Mathf.Round(value * 255f));
        }

        // Visszaad egy float-ot 0 és 1 között
        public static float Hex_to_Dec01(string hex)
        {
            return Hex_to_Dec(hex) / 255f;
        }

        // Hex Color FF00FF beolvasása "Color"-ból
        public static string GetStringFromColor(Color color)
        {
            string red = Dec01_to_Hex(color.r);
            string green = Dec01_to_Hex(color.g);
            string blue = Dec01_to_Hex(color.b);

            return red + green + blue;
        }

        // Hex Color FF00FFAA beolvasása "Color"-ból
        public static string GetStringFromColorWithAlpha(Color color)
        {
            string alpha = Dec01_to_Hex(color.a);

            return GetStringFromColor(color) + alpha;
        }

        // Beállítja az out értékeket a Hex String 'FF' számára
        public static void GetStringFromColor(Color color, out string red, out string green, out string blue, out string alpha)
        {
            red = Dec01_to_Hex(color.r);
            green = Dec01_to_Hex(color.g);
            blue = Dec01_to_Hex(color.b);
            alpha = Dec01_to_Hex(color.a);
        }

        // Hex Color FF00FF beolvasása RGB értékből
        public static string GetStringFromColor(float r, float g, float b)
        {
            string red = Dec01_to_Hex(r);
            string green = Dec01_to_Hex(g);
            string blue = Dec01_to_Hex(b);

            return red + green + blue;
        }

        // Hex Color FF00FFAA beolvasása RGBA értékből
        public static string GetStringFromColor(float r, float g, float b, float a)
        {
            string alpha = Dec01_to_Hex(a);

            return GetStringFromColor(r, g, b) + alpha;
        }

        // Color kinyerése a Hex string FF00FFAA-ból
        public static Color GetColorFromString(string color)
        {
            float red = Hex_to_Dec01(color.Substring(0, 2));
            float green = Hex_to_Dec01(color.Substring(2, 2));
            float blue = Hex_to_Dec01(color.Substring(4, 2));
            float alpha = 1f;
            if (color.Length >= 8)
            {
                // Color string tartalmaz alpha értéket
                alpha = Hex_to_Dec01(color.Substring(6, 2));
            }

            return new Color(red, green, blue, alpha);
        }
    }
}
