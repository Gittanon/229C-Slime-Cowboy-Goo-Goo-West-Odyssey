using UnityEngine;

public class MagnetZone : MonoBehaviour
{
    public PointEffector2D effector;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            effector.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            effector.enabled = false;
        }
    }
}