using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private Transform _transform;
    public string SHOOT = "Fire1";

    public GameObject laser;
    public Transform middle_gun;

    private float timer = 0f;
    public float shootSpeed = 0.35f;
    private bool shoot;

    private void Start() {
        _transform = this.GetComponent<Transform>();
        timer = shootSpeed;
    }

    private void Update() {
        shoot = Input.GetButton(SHOOT);
        timer += Time.deltaTime;
    }

    private void FixedUpdate() {
        if(shoot && timer >= shootSpeed) {
            Shoot();
        }
    }

    private void Shoot() {
        this.SpawnProjectile(middle_gun.transform, laser);
        timer = 0f;
    }

    private GameObject SpawnProjectile(Transform gun, GameObject bullet) {
        GameObject projectile = Instantiate(bullet, gun.position, _transform.rotation);
        projectile.gameObject.layer = this.gameObject.layer;
        return projectile;
    }
}