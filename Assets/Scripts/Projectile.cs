using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other){
        EnemyController p = other.collider.GetComponent<EnemyController>();

        if (p != null){
            p.ProjectileTouched();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
