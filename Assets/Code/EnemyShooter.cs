using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Stats")]
    public float fireRate = 2f;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public float bulletOffset = 0.8f;

    Transform player;
    float timer;
    bool playerInRange = false;

    void Update()
    {
        if (!playerInRange || player == null)
            return;

        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        Vector2 spawnPos = (Vector2)transform.position + dir * bulletOffset;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, angle);

        Instantiate(bulletPrefab, spawnPos, rot);
    }

    // 🔥 Player เข้ามาในพื้นที่
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerInRange = true;
        }
    }

    // 🔥 Player ออกพื้นที่
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            timer = 0f;
        }
    }
}