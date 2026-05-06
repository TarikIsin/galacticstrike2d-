using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 18f;
    [SerializeField] GameObject effect;

    private void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            Instantiate(effect, other.transform.position, Quaternion.identity);
            SoundManager.Instance.PlayMeteorExplosion();
            Destroy(other.gameObject);
        }
            
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
