using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 checkpointPosition;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // จุดเกิดเริ่มต้น ถ้ายังไม่โดน checkpoint
        checkpointPosition = transform.position;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
        Debug.Log("Checkpoint Saved");
    }

    public void Respawn()
    {
        transform.position = checkpointPosition;

        // รีเซ็ตแรงฟิสิกส์
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;
    }
}