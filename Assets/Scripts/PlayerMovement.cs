using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static float Health = 100f;
    public GameObject bullet;
    public Transform firePoint;
    private float bulletSpeed = 50;
    public GameObject player;

    private float maxTurnSpeed = 1000000.0f;
    private float smoothTime = 0.0003f;
    private float angle;
    private float currentVelocity;
    private float speed = 5.0f;

    public Texture2D cursorTexture;

    Vector2 lookDirection;
    float lookAngle;

    GameOverScript gameoverscript;

    private void Awake() {
       gameoverscript = FindObjectOfType<GameOverScript>();
       Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        BulletDirection();

        float targetAngle = Vector2.SignedAngle(Vector2.right, lookDirection);

        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocity, smoothTime, maxTurnSpeed);
        transform.eulerAngles = new Vector3(0, 0, angle);
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
    }

    private void BulletDirection() {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0) && !GameOverScript.isPaused) {
            Launch();
        }
    }

    private void Launch() {
        GameObject bulletClone = Instantiate(bullet);
        bulletClone.transform.position = firePoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController p = other.collider.GetComponent<EnemyController>();
         

        if (p != null){
            ChangeHealth(7);
            p.EnemyDie();
        }
    }

    public void ChangeHealth(int value) {
       float currentHealth = Health;
       Health = Mathf.Clamp(currentHealth, 0, 100);
       Health -= value;
       if (Health <= 0) {
            gameoverscript.PlayerGameOver();
            Debug.Log("Player died.");
       }
    }

}

