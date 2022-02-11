using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Image Health_Bar;
    public float CurrentHealth;
    private float maxHealth = 100f;
    PlayerMovement player;

    private void Start() {
        Health_Bar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update() {
        CurrentHealth = PlayerMovement.Health;
        Health_Bar.fillAmount = CurrentHealth / maxHealth;
    }

    

}
