using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    public float drag = 3.0f; // 🔥 ปรับความหนืดตรงนี้

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject,7.5f); // กันกระสุนค้าง
    }

    void FixedUpdate()
    {
        // 🔻 แรงต้านอากาศ
        rb.AddForce(-rb.linearVelocity * drag);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            var boss = other.GetComponentInParent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }
    }
}