using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] int maxHealth = 100;
    int health;

    [SerializeField] Image healthBar;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        health = maxHealth;
        HealthBarUpdate();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        HealthBarUpdate();

        if (health <= 0)
        {
            UIManager.Instance.OpenGameOverPanel();
            SoundManager.Instance.PlayPlayerExplosion();
            gameObject.SetActive(false);
        }
    }

    void HealthBarUpdate()
    {
        if (healthBar == null)
        {
            Debug.LogError("HealthBar atanmadı! Inspector'dan atayın.");
            return;
        }

        float healthPercent = (float)health / maxHealth;
        healthBar.fillAmount = healthPercent;
    }

}
