using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    private Transform _transform;
    public Vector3 _position => _transform.position;
    public Quaternion _rotation => _transform.rotation;
    public Vector3 startVector;

    private void Awake() {
        _transform = this.GetComponent<Transform>();
    }
}