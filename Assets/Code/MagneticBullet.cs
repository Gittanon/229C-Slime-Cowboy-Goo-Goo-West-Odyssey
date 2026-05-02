using UnityEngine;

public class MagneticBullet : MonoBehaviour
{
    public Transform target;

    public float initialSpeed = 8f;
    public float magneticForce = 5000f;
    public float maxSpeed = 25f;

    public float lifeTime = 3.5f; // อยู่ได้ 5 วินาที

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ยิงออกไป
        rb.linearVelocity = transform.right * initialSpeed;

        // หา Player
        if(target == null)
        {
            GameObject player =
                GameObject.FindGameObjectWithTag("Player");

            if(player != null)
                target = player.transform;
        }

        // ทำลายตัวเองเมื่อครบเวลา
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
    if(target == null) return;

    Vector2 toTarget = (Vector2)target.position - rb.position;

    float distance = toTarget.magnitude;

    Vector2 direction = toTarget.normalized;

    float gravityStrength = magneticForce / (distance * distance);

    rb.AddForce(direction * gravityStrength);

    if(rb.linearVelocity.magnitude > maxSpeed)
    {
        rb.linearVelocity =
        rb.linearVelocity.normalized * maxSpeed;
    }

    float angle =
    Mathf.Atan2(
        rb.linearVelocity.y,
        rb.linearVelocity.x
    ) * Mathf.Rad2Deg;

    transform.rotation =
    Quaternion.Euler(0,0,angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerRespawn player =
                other.GetComponent<PlayerRespawn>();

            if(player != null)
                player.Respawn();

            Destroy(gameObject);
        }
    }
}