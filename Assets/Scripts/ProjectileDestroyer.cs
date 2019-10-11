using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour {
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Projectile")) {
            Destroy(other.gameObject, 0f);
        }
    }
}