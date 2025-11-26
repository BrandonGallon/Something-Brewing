using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName = "Enemy";
    public float maxHealth = 1000f;
    private float currentHealth;
    public float deathDelay = 2f;

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(enemyName + " took " + damageAmount + " damage! Current health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(enemyName + " has been defeated!");
        Destroy(gameObject, deathDelay);
    }
}
