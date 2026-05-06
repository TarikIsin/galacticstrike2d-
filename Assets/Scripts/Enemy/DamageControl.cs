using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
