using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public string SHOOT = "Fire1";

    private Transform _transform;
    
    public Color playerColor;
    public GameObject laserBullet;
    public GunMode gunMode = GunMode.SINGLE;
    public Transform left_gun;
    public Transform middle_gun;
    public Transform right_gun;

    private float timer = 0f;
    [SerializeField] 
    public static float defaultSpeed = 0.35f;
    public float shotSpeed = 0.35f;
    private bool shoot;

    private void Awake() {
        _transform = this.GetComponent<Transform>();
        timer = shotSpeed;
    }

    private void Update() {
        shoot = Input.GetButton(SHOOT);
        timer += Time.deltaTime;
    }

    private void FixedUpdate() {
        if (shoot && timer >= shotSpeed) {
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
        projContr.SetShooter(this.gameObject);
        projectile.gameObject.layer = this.gameObject.layer;
        return projectile;
    }
    
    public void SetGunMode(GunMode mode) {
		this.gunMode = mode;
    }

    public void SetShotSpeed(float speed) {
        this.shotSpeed = speed;
    }
}