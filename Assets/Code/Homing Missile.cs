using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 8f;
    public float turnSpeed = 200f;
    public float lifeTime = 5f;

    Transform target;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if(player != null)
            target = player.transform;

        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        if(target == null) return;

        Vector2 direction =
            ((Vector2)target.position - rb.position).normalized;

        // หมุนกระสุนไปหาเป้าหมาย
        float rotateAmount =
            Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * turnSpeed;

        // พุ่งไปด้านหน้า
        rb.linearVelocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerRespawn p =
              other.GetComponent<PlayerRespawn>();

            if(p != null)
                p.Respawn();

            Destroy(gameObject);
        }
    }
}