using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Projectile") ||
            other.gameObject.CompareTag("Asteroid")) {
            Destroy(other.gameObject, 0f);
        }
    }
}