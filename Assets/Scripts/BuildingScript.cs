using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour {

    public static float Health = 100f;

    GameOverScript gameoverscript;

    private void Awake(){
        gameoverscript = FindObjectOfType<GameOverScript>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        EnemyController p = other.collider.GetComponent<EnemyController>();

        if (p != null) {
            ChangeBuildingHealth(2);
            p.ProjectileTouched();
        }
    }

    public void ChangeBuildingHealth(int value) {
        float currentHealth = Health;
        Health = Mathf.Clamp(currentHealth, 0, 100);
        Health -= value;
        if (Health <= 0)
        {
            gameoverscript.BuildingDestroyed();
            Debug.Log("Building Destroyed.");
        }
    }
}
