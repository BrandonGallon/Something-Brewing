using System;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    private void Die()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
