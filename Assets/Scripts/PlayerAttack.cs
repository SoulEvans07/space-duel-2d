using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private Transform _transform;
    public string SHOOT = "Fire1";

    public Color playerColor;
    public GameObject laserBullet;
    public GunMode gunMode = GunMode.SINGLE;
    public Transform left_gun;
    public Transform middle_gun;
    public Transform right_gun;

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
        if (shoot && timer >= shootSpeed) {
            Shoot();
        }
    }

    private void Shoot() {
        switch (gunMode) {
            case GunMode.SINGLE:
				SpawnProjectile(middle_gun.transform, laserBullet);
				break;
			case GunMode.DOUBLE:
				SpawnProjectile(left_gun.transform, laserBullet);
				SpawnProjectile(right_gun.transform, laserBullet);
				break;
			case GunMode.TRIPLE:
				SpawnProjectile(left_gun.transform, laserBullet);
				SpawnProjectile(middle_gun.transform, laserBullet);
				SpawnProjectile(right_gun.transform, laserBullet);
				break;
        }

        timer = 0f;
    }

    private GameObject SpawnProjectile(Transform gun, GameObject bullet) {
        GameObject projectile = Instantiate(bullet, gun.position, _transform.rotation);
        ProjectileController projContr = projectile.GetComponent<ProjectileController>();
        projContr.SetShooter(this);
        projectile.gameObject.layer = this.gameObject.layer;
        return projectile;
    }
}