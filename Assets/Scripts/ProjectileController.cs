using UnityEngine;

public class ProjectileController : MonoBehaviour {
    private Transform _transform;
    public MeshRenderer _renderer;
    public float speed = 0.15f;
    private PlayerAttack player;

    private void Awake() {
        _transform = this.GetComponent<Transform>();
        _renderer = this.GetComponent<MeshRenderer>();
    }
    
    private void FixedUpdate() {
        _transform.position += speed * _transform.up;
    }

    public void SetShooter(PlayerAttack player) {
        this.player = player;
        _renderer.materials[0].SetColor("_TintColor", player.playerColor);
    }
}