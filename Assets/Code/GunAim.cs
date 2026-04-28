using UnityEngine;

public class GunAim : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
            Input.mousePosition);

        Vector2 dir =
            mousePos - transform.position;

        float angle =
            Mathf.Atan2(dir.y,dir.x) *
            Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0,0,angle);

        if(mousePos.x < transform.position.x)
            transform.localScale =
                new Vector3(1,-1,1);
        else
            transform.localScale =
                new Vector3(1,1,1);
    }
}