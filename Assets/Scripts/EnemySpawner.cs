using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerBase;
    public float spawnRadius = 10f;
    public int initialWaveSize = 8;
    public int waveSizeIncrement = 4;
    public float minSpawnDistance = 10f;
    public float buttonCooldown = 5f; // Time in seconds for button cooldown.
    public Button spawnButton; // Reference to the UI button.
    [SerializeField]
    private PlacementSystem placementSystem;

    private int currentWave = 0;
    private int enemiesToSpawn;
    private float lastSpawnTime = 0;

    public int CurrentWave
    {
        get { return currentWave; }
    }

    private void Start()
    {
        enemiesToSpawn = initialWaveSize;
        lastSpawnTime = -buttonCooldown; // Initialize lastSpawnTime to ensure the button can be pressed immediately.
        spawnButton.onClick.AddListener(StartNextWave);
    }

    public void StartNextWave()
    {
        // Check if the button cooldown has passed.
        if (Time.time - lastSpawnTime < buttonCooldown)
        {
            return; // Button is still on cooldown, so do nothing.
        }
        placementSystem.StopPlacement();
        Vector3 playerPosition = playerBase.position;
        playerPosition.y = 0;

        // Spawn the specified number of enemies for the current wave.
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition;
            do
            {
                spawnPosition = playerPosition + Random.insideUnitSphere * spawnRadius;
                spawnPosition.y = 0;
            } while (Vector3.Distance(spawnPosition, playerPosition) < minSpawnDistance);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<EnemyAI>().SetTarget(playerBase);
        }

        // Update the round number and increment the number of enemies for the next wave.
        currentWave++;
        enemiesToSpawn += waveSizeIncrement;

        // Set the lastSpawnTime to the current time to start the cooldown.
        lastSpawnTime = Time.time;
    }
}
