using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disapperTimer;
    private Color textColor;

    // Felugró sebzésszöveg létrehozása
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.damagePopupPrefab, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        disapperTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 20f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disapperTimer -= Time.deltaTime;

        if (disapperTimer < 0)
        {
            // Az idózítő lejárta után elkezd eltűnni
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            //Miután már nem látszik nyugodtan elpusztíthatjuk
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
