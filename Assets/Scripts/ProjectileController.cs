using UnityEngine;

public class ProjectileController : MonoBehaviour {
    private Transform _transform;
    public float speed = 0.15f;

    private void Start() {
        _transform = this.GetComponent<Transform>();
    }
    
    private void FixedUpdate() {
        _transform.position += speed * _transform.up;
    }
}