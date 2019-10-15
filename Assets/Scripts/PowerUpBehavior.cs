using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private PlayerPowerupHandler handler;
    [SerializeField]
    private PowerUp powerUp;

    public Vector2 direction;
    public float speed;

    private void Awake() {
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        bool isProjectile = other.CompareTag("Projectile");
        bool isPlayer = other.CompareTag("Player");

        if (isProjectile || isPlayer) {
            if (isProjectile) {
                handler = other.GetComponent<ProjectileController>().GetShooter();
                Destroy(other.gameObject);
            }

            if (isPlayer) {
                handler = other.GetComponent<PlayerPowerupHandler>();
            }

            Destroy(this.gameObject);
            ApplyPowerUp();
        }
    }

    public void SetPowerUp(PowerUp _powerup) {
        powerUp = _powerup;
        this.gameObject.name = _powerup.name;
    }

    public void ApplyPowerUp() {
        handler.ActivatePowerUp(powerUp);
    }

    public void SetVelocity(Vector2 _direction, float _speed) {
        this.direction = _direction;
        this.speed = _speed;
        this._rigidbody.velocity = _direction * _speed;
    }
}