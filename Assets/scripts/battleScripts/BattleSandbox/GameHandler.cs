using UnityEngine;
using DumbLuck;

public class GameHandler : MonoBehaviour
{
    public Transform healthBarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(healthBarPrefab, new Vector3(0, 10), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        Debug.Log("Health: " + healthSystem.GetHealthPercent());
        healthSystem.Damage(10);
        Debug.Log("Health: " + healthSystem.GetHealthPercent());

        DebugHelper.ButtonUI(new Vector2(100, 100), "Damage", () =>
        {
            healthSystem.Damage(10);
            Debug.Log("Damaged: " + healthSystem.GetHealth());
        });

        DebugHelper.ButtonUI(new Vector2(-100, 100), "Heal", () =>
        {
            healthSystem.Heal(10);
            Debug.Log("Healed: " + healthSystem.GetHealth());
        });
    }
}
