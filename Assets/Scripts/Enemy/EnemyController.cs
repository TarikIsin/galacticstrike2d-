using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] positions;
    public float speed = 5f;
    public int damage = 25;

    int index = 0;

    private void Update()
    {
        if (positions.Length == 0) return;

        Transform target = positions[index];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            index++;

            if (index >= positions.Length)
            {
                index = 0;
                transform.position = positions[0].position; // İlk pozisyona ışınlan
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            GameManager.instance.RemoveEnemy(this.gameObject);
            SoundManager.Instance.PlayEnemyExplosion();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.RemoveEnemy(this.gameObject);
            PlayerStats.Instance.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}