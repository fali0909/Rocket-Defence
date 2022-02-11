using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 5.0f;

    [SerializeField] private GameObject explosionEffect;

    private Transform target;

    private Vector2 movement;

    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    public Rigidbody2D rigidbody2d;

    private void Start() {
        explosionEffect.SetActive(false);
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Building").GetComponent<Transform>();
    }

    private void Update() {   
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    public void ProjectileTouched() {
        explosionEffect.SetActive(true);
        EnemyDie();  
    }

    public void EnemyDie() {
        Destroy(gameObject); 

        if (OnEnemyKilled != null) {
            OnEnemyKilled();
        }
    }
}
