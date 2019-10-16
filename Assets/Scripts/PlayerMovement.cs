using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public string AXIS_X = "Horizontal";
    public string AXIS_Y = "Vertical";

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private Vector2 direction;
    public float maxSpeed;

    private void Awake() {
        _transform = this.GetComponent<Transform>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        direction.x = Input.GetAxisRaw(AXIS_X);
        direction.y = Input.GetAxisRaw(AXIS_Y);
        direction.Normalize();
    }

    private void FixedUpdate() {
        Move(this.direction, this.maxSpeed);
    }

    private void Move(Vector2 direction, float speed) {
        Vector2 nextPos = this._rigidbody.position +
            direction * speed * Time.fixedDeltaTime;
        
        if (nextPos.x < GameAreaManager.MIN_WIDTH || nextPos.x > GameAreaManager.MAX_WIDTH) {
			nextPos.x = _rigidbody.position.x;
        }
		if (nextPos.y < GameAreaManager.BOTTOM || nextPos.y > GameAreaManager.TOP) {
			nextPos.y = _rigidbody.position.y;
        }

        this._rigidbody.MovePosition(nextPos);
    }
}