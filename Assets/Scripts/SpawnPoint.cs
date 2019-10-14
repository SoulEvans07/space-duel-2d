using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPoint : MonoBehaviour {
    private Transform _transform;
    public Vector3 _position => _transform.position;
    public Quaternion _rotation => _transform.rotation;
    public Vector2 startVector;
    public float xOffset = 0f;
    public float yOffset = 0.2f;

    private void Awake() {
        _transform = this.GetComponent<Transform>();
    }

    public Vector2 GetStartVector() {
        Vector2 nextVector = new Vector2(
            Random.Range(
                startVector.x - xOffset, 
                startVector.x + xOffset
            ),
            Random.Range(
                startVector.y - yOffset, 
                startVector.y + yOffset
            )
        );
        nextVector.Normalize();
        return nextVector;
    }
}