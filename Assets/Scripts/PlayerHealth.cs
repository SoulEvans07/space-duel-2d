using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    private PlayerAttack _playerAttack;
    private PlayerMovement _playerMovement;

    public int maxHealth = 100;
    public int healthValue;

    private float timer = 0f;
    public float iframes = 0.006f;

    private bool isDead;
    public bool IsDead => isDead;

    private void Awake() {
        _playerAttack = this.GetComponent<PlayerAttack>();
        _playerMovement = this.GetComponent<PlayerMovement>();

        isDead = false;
        timer = iframes;
        healthValue = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (timer >= iframes) {
            HandleHit(other.gameObject);
        }
    }

    private void HandleHit(GameObject other) {
        string tag = other.tag;
        int dmg = other.GetComponent<ProjectileController>().dmg;

        switch (tag) {
            case "Projectile":
                TakeDamage(dmg);
                Destroy(other);
                break;
            case "Player":
                TakeDamage((int) Math.Floor(maxHealth / 4f));
                timer = 0f;
                break;
            // case "Laser": 
            //     break;
            // case "Asteroid":
            //     break;
        }
    }

    private void TakeDamage(int dmg) {
        healthValue -= dmg;
        // play hit anim
        Debug.Log("[" + this.name + "] " + healthValue + "/" + maxHealth);

        if (healthValue < 0) {
            healthValue = 0;
        }

        // update health display

        if (healthValue == 0) {
            Death();
        }
    }

    private void Death() {
        isDead = true;
        Debug.Log(this.name + " is dead!");
        Destroy(this.gameObject);
    }
}