using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DumbLuck.Utilities
{
    /*
     * Különböző, válogatott, több helyen is használható funkciók gyűjtőhelye ez a script.
     * Idővel bővülni fog a tárház és az egyszerűbb használhatóság végett namespace-be foglaltam.
     */

    public static class UtilsClass
    {
        private static readonly Vector3 Vector3zero = Vector3.zero;
        private static readonly Vector3 Vector3one = Vector3.one;
        private static readonly Vector3 Vector3yDown = new Vector3(0, -1);

        public const int sortingOrderDefault = 5000;

        // Vissza adja a rendezési sorrendet a SpriteRenderer számára, magasabb pozíció = alacsonyabb rendezési sorszám (sortingOrder)
        public static int GetSortingOrder(Vector3 position, int offset, int baseSortingOrder = sortingOrderDefault)
        {
            return (int)(baseSortingOrder - position.y) + offset;
        }

        // Visszaadja a Main Canvas Transform-ját
        private static Transform cachedCanvasTransform;
        public static Transform GetCanvasTransform()
        {
            if (cachedCanvasTransform == null)
            {
                Canvas canvas = MonoBehaviour.FindObjectOfType<Canvas>();
                if (canvas != null)
                {
                    cachedCanvasTransform = canvas.transform;
                }
            }

            return cachedCanvasTransform;
        }

        // Visszaadja a Unity alap betűstílusát a text objektumok számára, ha nincs külön stílus meghatározva
        public static Font GetDefaultFont()
        {
            return Resources.GetBuiltinResource<Font>("Arial.ttf");
        }


        // Létrehoz egy Sprite-ot a World-ben, szülő nélkül
        public static GameObject CreateWorldSprite(string name, Sprite sprite, Vector3 position, Vector3 localScale, int sortingOrder, Color color)
        {
            return CreateWorldSprite(null, name, sprite, position, localScale, sortingOrder, color);
        }

        // Létrehoz egy Sprite-ot a World-ben
        public static GameObject CreateWorldSprite(Transform parent, string name, Sprite sprite, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
        {
            GameObject gameObject = new GameObject(name, typeof(SpriteRenderer));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            transform.localScale = localScale;
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = sortingOrder;
            spriteRenderer.color = color;

            return gameObject;
        }

        // Létrehoz egy Sprite-ot a World-ben, Button_Sprite-tal, szülő nélkül
        public static Button_Sprite CreateWorldSpriteButton(string name, Sprite sprite, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
        {
            return CreateWorldSpriteButton(null, name, sprite, localPosition, localScale, sortingOrder, color);
        }

        // Létrehoz egy Sprite-ot a World-ben, Button_Sprite-tal
        public static Button_Sprite CreateWorldSpriteButton(Transform parent, string name, Sprite sprite, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
        {
            GameObject gameObject = CreateWorldSprite(parent, name, sprite, localPosition, localScale, sortingOrder, color);
            gameObject.AddComponent<BoxCollider2D>();
            Button_Sprite buttonSprite = gameObject.AddComponent<Button_Sprite>();
            
            return buttonSprite;
        }

        // Létrehoz egy Text Mesh-t a World-ben and és folyamatosan frissítí azt
        public static FunctionUpdater CreateWorldTextUpdater(Func<string> GetTextFunc, Vector3 localPosition, Transform parent = null)
        {
            TextMesh textMesh = CreateWorldText(GetTextFunc(), parent, localPosition);
            
            return FunctionUpdater.Create(() =>
            {
                textMesh.text = GetTextFunc();
                return false;
            }, "WorldTextUpdater");
        }

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

        // Visszaad 00-FF, ahol a value: 0->255 közötti
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

        // Létrehoz egy Text Popup-ot a World-ben, szülő nélkül
        public static void CreateWorldTextPopup(string text, Vector3 localPosition)
        {
            CreateWorldTextPopup(null, text, localPosition, 40, Color.white, localPosition + new Vector3(0, 20), 1f);
        }

        // Létrehoz egy Text Popup-ot a World-ben
        public static void CreateWorldTextPopup(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, Vector3 finalPopupPosition, float popupTime)
        {
            TextMesh textMesh = CreateWorldText(parent, text, localPosition, fontSize, color, TextAnchor.LowerLeft, TextAlignment.Left, sortingOrderDefault);
            Transform transform = textMesh.transform;
            Vector3 moveAmount = (finalPopupPosition - localPosition) / popupTime;
            FunctionUpdater.Create(delegate ()
            {
                transform.position += moveAmount * Time.deltaTime;
                popupTime -= Time.deltaTime;
                if (popupTime <= 0f)
                {
                    UnityEngine.Object.Destroy(transform.gameObject);
                    return true;
                }
                else
                {
                    return false;
                }
            }, "WorldTextPopup");
        }

        // Létrehoz egy Text Updater-t az UI felületen
        public static FunctionUpdater CreateUITextUpdater(Func<string> GetTextFunc, Vector2 anchoredPosition)
        {
            Text text = DrawTextUI(GetTextFunc(), anchoredPosition, 20, GetDefaultFont());
            return FunctionUpdater.Create(() =>
            {
                text.text = GetTextFunc();
                return false;
            }, "UITextUpdater");
        }


        // Rajzol egy UI Sprite-ot
        public static RectTransform DrawSprite(Color color, Transform parent, Vector2 pos, Vector2 size, string name = null)
        {
            RectTransform rectTransform = DrawSprite(null, color, parent, pos, size, name);
            return rectTransform;
        }

        // Rajzol egy UI Sprite-ot
        public static RectTransform DrawSprite(Sprite sprite, Transform parent, Vector2 pos, Vector2 size, string name = null)
        {
            RectTransform rectTransform = DrawSprite(sprite, Color.white, parent, pos, size, name);
            return rectTransform;
        }

        // Rajzol egy UI Sprite-ot
        public static RectTransform DrawSprite(Sprite sprite, Color color, Transform parent, Vector2 pos, Vector2 size, string name = null)
        {
            // Setup icon
            if (name == null || name == "") name = "Sprite";
            GameObject go = new GameObject(name, typeof(RectTransform), typeof(Image));
            RectTransform goRectTransform = go.GetComponent<RectTransform>();
            goRectTransform.SetParent(parent, false);
            goRectTransform.sizeDelta = size;
            goRectTransform.anchoredPosition = pos;

            Image image = go.GetComponent<Image>();
            image.sprite = sprite;
            image.color = color;

            return goRectTransform;
        }

        public static Text DrawTextUI(string textString, Vector2 anchoredPosition, int fontSize, Font font)
        {
            return DrawTextUI(textString, GetCanvasTransform(), anchoredPosition, fontSize, font);
        }

        public static Text DrawTextUI(string textString, Transform parent, Vector2 anchoredPosition, int fontSize, Font font)
        {
            GameObject textGo = new GameObject("Text", typeof(RectTransform), typeof(Text));
            textGo.transform.SetParent(parent, false);
            Transform textGoTrans = textGo.transform;
            textGoTrans.SetParent(parent, false);
            textGoTrans.localPosition = Vector3zero;
            textGoTrans.localScale = Vector3one;

            RectTransform textGoRectTransform = textGo.GetComponent<RectTransform>();
            textGoRectTransform.sizeDelta = new Vector2(0, 0);
            textGoRectTransform.anchoredPosition = anchoredPosition;

            Text text = textGo.GetComponent<Text>();
            text.text = textString;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.alignment = TextAnchor.MiddleLeft;
            if (font == null) font = GetDefaultFont();
            text.font = font;
            text.fontSize = fontSize;

            return text;
        }

        // Elemez egy float-ot, visszaadja az alapértéket, ha sikertelen
        public static float Parse_Float(string txt, float _default)
        {
            float f;
            if (!float.TryParse(txt, out f))
            {
                f = _default;
            }
            return f;
        }

        // Elemez egy int-et, visszaadja az alapértéket, ha sikertelen
        public static int Parse_Int(string txt, int _default)
        {
            int i;
            if (!int.TryParse(txt, out i))
            {
                i = _default;
            }
            return i;
        }

        public static int Parse_Int(string txt)
        {
            return Parse_Int(txt, -1);
        }
    }
}
