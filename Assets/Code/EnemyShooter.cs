using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float fireRate = 2f;
    public float activeDistance = 15f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    Transform player;
    float timer;

    void Start()
    {
        player =
         GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(player == null) return;

        float distance =
           Vector2.Distance(
               transform.position,
               player.position
           );

        if(distance > activeDistance)
            return;

        timer += Time.deltaTime;

        if(timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(
          bulletPrefab,
          firePoint.position,
          firePoint.rotation
        );
    }
}