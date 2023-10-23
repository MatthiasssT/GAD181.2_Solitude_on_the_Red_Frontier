using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 100; // Adjust as needed
    private int currentHealth;
    public int damageAmount = 5;
    public float moveSpeed = 3f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (target == null)
            return;

        // Move towards the player base.
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Update rotation to look at the player base.
        transform.LookAt(target);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Enemy is destroyed, you can add destruction logic here.
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBase"))
        {
            // Deal a fixed amount of damage to the player base and destroy the enemy.
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Deal a fixed amount of damage to the player base.
            }

            Destroy(gameObject); // Destroy the enemy.
        }
    }
}

