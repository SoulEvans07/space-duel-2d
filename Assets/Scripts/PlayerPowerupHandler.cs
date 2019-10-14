using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerupHandler : MonoBehaviour {
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;

    public Slider powerupSlider;
    
    private PowerUp activePowerup;
    private float timer;
    private float duration;

    private void Awake() {
        activePowerup = null;
        powerupSlider.value = 0f;
    }

    private void Update() {
        if (activePowerup != null) {
            timer -= Time.deltaTime;

            if (timer <= 0f) {
                activePowerup.Remove(this);
                timer = 0f;
                activePowerup = null;
            }
            
            if (timer / duration != powerupSlider.value) {
                powerupSlider.value = timer / duration;
            }
        }
    }

    public void ActivatePowerUp(PowerUp powerUp) {
        activePowerup?.Remove(this);

        activePowerup = powerUp;
        timer = powerUp.duration;
        duration = powerUp.duration;
        powerupSlider.value = 1f;
        
        powerUp.Apply(this);
    }

    public void Heal(int amount) {
        playerHealth.Heal(amount);
    }

    public void SetGunMode(GunMode mode) {
        playerAttack.SetGunMode(mode);
    }
}