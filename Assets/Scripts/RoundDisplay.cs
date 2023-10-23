using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundDisplay : MonoBehaviour
{
    public TextMeshProUGUI roundNumberText;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); // Find the EnemySpawner in the scene.
        UpdateRoundNumberText();
    }

    private void Update()
    {
        if (enemySpawner != null)
        {
            UpdateRoundNumberText();
        }
    }

    void UpdateRoundNumberText()
    {
        roundNumberText.text = "Wave: " + enemySpawner.CurrentWave.ToString();
    }
}
