using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHealthBar : MonoBehaviour {

    private Image Health_Bar;
    public float CurrentHealth;
    private float maxHealth = 100f;
    BuildingScript building;

    private void Start() {
        Health_Bar = GetComponent<Image>();
        building = FindObjectOfType<BuildingScript>();
    }

    private void Update() {
        CurrentHealth = BuildingScript.Health;
        Health_Bar.fillAmount = CurrentHealth / maxHealth;
    }
}
