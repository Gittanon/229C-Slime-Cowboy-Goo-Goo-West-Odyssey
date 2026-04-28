using UnityEngine;

public class EnemyHealth : MonoBehaviour
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

        ScoreManager.instance.AddScore(
            scoreValue
        );

        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }
}