using UnityEngine;

public class ProjectileController : MonoBehaviour {
    private Transform _transform;
    private MeshRenderer _renderer;
    private PlayerAttack player;
    private PlayerPowerupHandler handler;
    
    public float speed = 0.15f;
    public float dmg = 1f;

    private void Awake() {
        _transform = this.GetComponent<Transform>();
        _renderer = this.GetComponent<MeshRenderer>();
    }
    
    private void FixedUpdate() {
        _transform.position += speed * _transform.up;
    }

    public void SetShooter(GameObject player) {
        this.player = player.GetComponent<PlayerAttack>();
        this.handler = player.GetComponent<PlayerPowerupHandler>();
        _renderer.materials[0].SetColor("_TintColor", this.player.playerColor);
    }

    public PlayerPowerupHandler GetShooter() {
        return this.handler;
    }
}