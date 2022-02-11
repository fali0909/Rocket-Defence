using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

   // public Transform[] m_SpawnPoints;
   // public GameObject[] enemy;
    public GameObject m_EnemyPrefab;
    private int currentAmount = 5;
  //  [SerializeField] private GameObject enemyclone;
   // private bool spawning;
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
            currentAmount = currentAmount + 2;
            currentSpawnTime = 0;
            
        }
        if (GameOverScript.isPaused) {
            currentAmount = 5;
        }


    }


    public void SpawnNewEnemy(int enemies) {

        //enemies++;
      //  int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length - 1));

        for (int i = 0; i < enemies; i++) {
          //  GameObject CoinClone = Instantiate(enemyclone, new Vector3(i * 0.6f, enemyclone.transform.position.y, i * 0.75f), Quaternion.identity);
            Instantiate(m_EnemyPrefab, new Vector2(m_EnemyPrefab.transform.position.y, i * 5), Quaternion.identity);
        }
        //Vector3 enemyPos = new Vector3(Random.Range(-2.8f, 2.8f), transform.position.y, transform.position.z);
        //enemyNo = Random.Range(0, 27); 
      //  Instantiate(m_EnemyPrefab, m_SpawnPoints[0].transform.position, Quaternion.identity);
        //Instantiate(enemy[0], enemyPos, Quaternion.identity);
    }

}
