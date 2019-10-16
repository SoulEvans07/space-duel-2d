using UnityEngine;

public class AsteroidController : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    public float dmg = 1f;
    public Vector2 direction;
    public float speed = 1f;


    private void Awake() {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _renderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Projectile")) {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void SetSprite(Sprite sprite) {
        _renderer.sprite = sprite;
    }

    public void SetVelocity(Vector2 _direction, float _speed) {
        this.direction = _direction;
        this.speed = _speed;
        this._rigidbody.velocity = _direction * _speed;
    }
}
