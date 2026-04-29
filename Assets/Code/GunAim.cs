using UnityEngine;

public class GunAim : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 dir = mousePos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // หมุนปืน
        transform.rotation = Quaternion.Euler(0,0,angle);

        // Flip เมื่อเมาส์อยู่ซ้ายตัวละคร
        if (dir.x < 0)
            transform.localScale = new Vector3(1,-1,1);
        else
            transform.localScale = new Vector3(1,1,1);
    }
}