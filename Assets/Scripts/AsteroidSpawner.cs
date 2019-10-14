using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour {
    [Range(0, 1)]
    public float powerupAsteroidProbability = 0.9f;
    public float spawnTime = 1f;
    public GameObject asteroidPrefab;
    public Transform asteroidContainer;
    public float[] speeds = { 2f, 5f, 5f, 5f, 5f, 7f, 7f };
    public Sprite[] asteroidSprites;
    public SpawnPoint[] spawnPoints;

    private void Awake() {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn() {
        float speed = speeds[Random.Range(0, speeds.Length)];
        SpawnPoint spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject asteroid = Instantiate(
            asteroidPrefab,
            spawnPoint._position,
            spawnPoint._rotation
        );

        Sprite asteroidSprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        AsteroidController astrContr = asteroid.GetComponent<AsteroidController>();
        astrContr.SetSprite(asteroidSprite);
        astrContr.SetVelocity(spawnPoint.GetStartVector(), speed);
        asteroid.transform.parent = asteroidContainer;
    }
}