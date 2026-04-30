using UnityEngine;

public class CreditScroll : MonoBehaviour
{
    public float scrollSpeed = 50f;

    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}