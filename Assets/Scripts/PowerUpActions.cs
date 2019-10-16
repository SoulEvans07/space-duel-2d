using UnityEngine;

public class PowerUpActions : MonoBehaviour {
	public void HealApplyAction(PlayerPowerupHandler controller) {
		controller.Heal(20);
	}

	public void DoubleGunApplyAction(PlayerPowerupHandler controller) {
		controller.SetGunMode(GunMode.DOUBLE);
	}

	public void DoubleGunRemoveAction(PlayerPowerupHandler controller) {
		controller.SetGunMode(GunMode.SINGLE);
	}

	public void TripleGunApplyAction(PlayerPowerupHandler controller) {
		controller.SetGunMode(GunMode.TRIPLE);
	}

	public void TripleGunRemoveAction(PlayerPowerupHandler controller) {
		controller.SetGunMode(GunMode.SINGLE);
	}
}