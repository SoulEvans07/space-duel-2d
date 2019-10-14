using UnityEngine;

public class AsteroidController : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    public int dmg = 1;
    public Vector2 direction;
    public float speed = 1f;


    private void Awake() {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _renderer = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        Move(direction, speed);
    }

    private void Move(Vector2 direction, float speed) {
        Vector2 nextPos = this._rigidbody.position +
            direction * speed * Time.fixedDeltaTime;

        this._rigidbody.MovePosition(nextPos);
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
    }
}
