using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit Game"); // ไว้เช็คใน Editor

        Application.Quit();
    }
}