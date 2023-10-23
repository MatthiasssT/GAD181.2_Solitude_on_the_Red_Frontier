using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    public float range = 10f;
    public GameObject projectilePrefab;
    

    private void Update()
    {
        FindClosestEnemyAndShoot();
    }

    void FindClosestEnemyAndShoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Assuming enemies have a "Enemy" tag.

        Transform closestEnemy = null;
        float closestDistance = range;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestEnemy = enemy.transform;
                closestDistance = distance;
            }
        }

        if (closestEnemy != null)
        {
            // Rotate the turret to face the closest enemy.
            transform.LookAt(closestEnemy);

            // Shoot a projectile at the closest enemy.
            ShootAt(closestEnemy);
        }
    }

    void ShootAt(Transform target)
    {
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        // You may want to set properties on the bullet like damage and target here.
        // Then, handle the bullet logic in a separate script.
    }
}
