using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    private PlayerAttack _playerAttack;
    private PlayerMovement _playerMovement;

    public Slider healthSlider;

    public float maxHealth = 100f;
    public float healthValue;

    public float timer = 0f;
    public float iframes = 4f;

    private bool isDead;
    public bool IsDead => isDead;

    private void Awake() {
        _playerAttack = this.GetComponent<PlayerAttack>();
        _playerMovement = this.GetComponent<PlayerMovement>();

        isDead = false;
        timer = iframes;
        healthValue = maxHealth;
        healthSlider.value = healthValue / maxHealth;
    }

    private void Update() {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        HandleHit(other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other) {
        HandleHit(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        HandleHit(other.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other) {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject other) {
        if (timer < iframes) return;

        string tag = other.tag;
        switch (tag) {
            case "Projectile":
                TakeDamage(other.GetComponent<ProjectileController>().dmg);
                Destroy(other);
                break;
            case "Player":
                TakeDamage((int) Math.Floor(maxHealth / 4f));
                timer = 0f;
                break;
            // case "Laser": 
            //     break;
            case "Asteroid":
                TakeDamage(other.GetComponent<AsteroidController>().dmg);
                Destroy(other.gameObject);
                break;
            case "DangerZone":
                TakeDamage(other.GetComponent<DangerZone>().dmg);
                break;
        }
    }

    private void TakeDamage(float dmg) {
        healthValue -= dmg;
        // play hit anim

        if (healthValue < 0) {
            healthValue = 0;
        }

        healthSlider.value = (float) healthValue / (float) maxHealth;

        if (healthValue == 0) {
            Death();
        }
    }

    public void Death() {
        isDead = true;
        Debug.Log(this.name + " is dead!");
        Destroy(this.gameObject);
    }

    public void Heal(int amount) {
        healthValue += amount;
        if (healthValue > maxHealth) {
            healthValue = maxHealth;
        }
        healthSlider.value = (float) healthValue / (float) maxHealth; 
    }
}