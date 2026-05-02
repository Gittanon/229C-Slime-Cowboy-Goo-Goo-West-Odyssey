using UnityEngine;

public class EnemyHealth1 : MonoBehaviour
{
    public int maxHealth = 100;

    public int scoreValue = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy HP : " + currentHealth);


        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

   Debug.Log("Boss Died");

        ScoreManager.instance.AddScore(scoreValue);

        GameManager.instance.GameOver(); // 🔥 ตัวสำคัญ

        Destroy(gameObject);
    }
}