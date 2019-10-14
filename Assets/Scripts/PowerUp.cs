using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PowerUp {
	[SerializeField] public string name;
	[SerializeField] public float duration;
	[SerializeField] public PowerUpEvent applyAction;
	[SerializeField] public PowerUpEvent removeAction;

	public void Apply(PlayerPowerupHandler handler) {
		applyAction?.Invoke(handler);
	}

	public void Remove(PlayerPowerupHandler handler) {
		removeAction?.Invoke(handler);
	}

	[Serializable]
	public class PowerUpEvent : UnityEvent<PlayerPowerupHandler> {
	}
}