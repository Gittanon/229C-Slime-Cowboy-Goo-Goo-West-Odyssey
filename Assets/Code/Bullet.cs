using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject,7.5f); //กันกระสุนค้าง
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject); //กระสุนหายเมื่อโดน
        }
    }
}