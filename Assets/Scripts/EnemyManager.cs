using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


    public GameObject m_EnemyPrefab;
    private int currentAmount = 5;
    public float spawnInterval = 10f;
    public float currentSpawnTime = 15f;

    GameOverScript gameoverscript;


    private void Awake() {
        gameoverscript = FindObjectOfType<GameOverScript>();
    }

    private void Update() {

       
        currentSpawnTime += Time.deltaTime;

        if (currentSpawnTime >= spawnInterval && !GameOverScript.isPaused) {
            
            SpawnNewEnemy(currentAmount);
            currentAmount += 2;
            currentSpawnTime = 0;
            
        }
        if (GameOverScript.isPaused) {
            currentAmount = 5;
        }


    }


    public void SpawnNewEnemy(int enemies) {
        for (int i = 0; i < enemies; i++) {
            Instantiate(m_EnemyPrefab, new Vector2(m_EnemyPrefab.transform.position.y, i * 5), Quaternion.identity);
        }
    }

}
