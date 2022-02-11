using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour {

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI _title;
    public static bool isPaused;

    PlayerMovement player;
    BuildingScript building;

    private void Awake() {
        building = FindObjectOfType<BuildingScript>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Start() {
        gameOverUI.SetActive(false);
    }

    public void PlayerGameOver() {
        isPaused = true;
        gameOverUI.SetActive(true);
        _title.text = "Player died";
        Time.timeScale = 0f;
        Debug.Log("GameOver");
    }

    public void BuildingDestroyed() {
        isPaused = true;
        gameOverUI.SetActive(true);
        _title.text = "The building is destroyed";
        Time.timeScale = 0f;
        Debug.Log("GameOver");
    }

    public void RetryGame() {
        isPaused = false;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player.transform.position = new Vector3(46.3f, 2.1f, 0f);
        BuildingScript.Health = 100f;
        PlayerMovement.Health = 100f;
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }
}
