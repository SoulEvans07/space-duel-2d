using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public string AXIS_X = "Horizontal";
    public string AXIS_Y = "Vertical";

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private Vector2 direction;
    public float maxSpeed;

    private void Start() {
        _transform = this.GetComponent<Transform>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        direction.x = Input.GetAxisRaw(AXIS_X);
        direction.y = Input.GetAxisRaw(AXIS_Y);
    }

    private void FixedUpdate() {
        Move(this.direction, this.maxSpeed);
    }

    private void Move(Vector2 direction, float speed) {
        Vector2 nextPos = this._rigidbody.position +
            direction * speed * Time.fixedDeltaTime;
        // TODO: boundaries validation
        this._rigidbody.MovePosition(nextPos);
    }
}