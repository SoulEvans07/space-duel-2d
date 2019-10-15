using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour {
    [Range(0, 1)] public float powerupProbability;
    [Range(0, 1)] public float powerupAsteroidProbability = 0.9f;
    public float spawnTime = 1f;
    public GameObject asteroidPrefab;
    public Transform asteroidContainer;
    public float[] speeds = { 2f, 5f, 5f, 5f, 5f, 7f, 7f };
    public Sprite[] asteroidSprites;
    public PowerUpElement[] powerUps;
    private List<int> powerupIndexes;
    public SpawnPoint[] spawnPoints;

    private void Awake() {
        powerupIndexes = new List<int>();
		for (int i = 0; i < powerUps.Length; i++) {
			for (int k = 0; k < powerUps[i].spawn_weight; k++) {
				powerupIndexes.Add(i);
			}
		}

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn() {
        float speed = speeds[Random.Range(0, speeds.Length)];
        SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        bool spawnPowerup = Random.Range(0, 1f) < powerupProbability;
        if (spawnPowerup) {
            SpawnPowerup(spawnPoint, speed);
        } else {
            SpawnAsteroid(spawnPoint, speed);
        }
    }

    private void SpawnPowerup(SpawnPoint spawnPoint, float speed) {
        int index = powerupIndexes[Random.Range(0, powerupIndexes.Count)];
        GameObject powerupPrefab = powerUps[index].powerUpPrefab;
        GameObject powerup = Instantiate(
            powerupPrefab,
            spawnPoint._position,
            spawnPoint._rotation
        );

        PowerUpBehavior puContr = powerup.GetComponent<PowerUpBehavior>();
        puContr.SetVelocity(spawnPoint.GetStartVector(), speed);
        puContr.GetComponent<Collider2D>().enabled = true;
    }

    private void SpawnAsteroid(SpawnPoint spawnPoint, float speed) {
        GameObject asteroid = Instantiate(
            asteroidPrefab,
            spawnPoint._position,
            spawnPoint._rotation
        );

        Sprite asteroidSprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        AsteroidController astrContr = asteroid.GetComponent<AsteroidController>();
        astrContr.SetSprite(asteroidSprite);
        astrContr.SetVelocity(spawnPoint.GetStartVector(), speed);
        asteroid.transform.localScale = spawnPoint.GetScale();
        asteroid.transform.parent = asteroidContainer;
    }

    [Serializable]
	public class PowerUpElement {
		public GameObject powerUpPrefab;
		public int spawn_weight = 1;
	}
}