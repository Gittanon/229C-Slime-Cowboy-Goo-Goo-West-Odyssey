using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 4f;

    private Vector3 startPos;
    private int direction = 1; // 1=ขวา, -1=ซ้าย

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // เดิน
        transform.position += Vector3.right *
                              direction *
                              moveSpeed *
                              Time.deltaTime;

        // ถึงขอบขวา
        if(transform.position.x >= startPos.x + patrolDistance)
        {
            direction = -1;
            Flip();
        }

        // ถึงขอบซ้าย
        if(transform.position.x <= startPos.x - patrolDistance)
        {
            direction = 1;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerRespawn player =
                other.gameObject.GetComponent<PlayerRespawn>();

            if(player != null)
                player.Respawn();
        }
    }
}