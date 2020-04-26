using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSpawner : MonoBehaviour
{
    private GameObject player;

    private bool continueSpawning;

    private Vector3 spawnPos;
    private WaitForSeconds spawnInterval = new WaitForSeconds(4.5f);

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Spawn_Speed_Boosters(Vector3 spawnPos)
    {
        GameObject speedBooster = Spawner.instance.GetPooledPickUp("SpeedBooster(Clone)");
        speedBooster.SetActive(true);
        speedBooster.transform.position = spawnPos;
    }
    void Spawn_Score_Boosters(Vector3 spawnPos)
    {
        GameObject scoreBooster = Spawner.instance.GetPooledPickUp("ScoreBooster(Clone)");
        scoreBooster.SetActive(true);
        scoreBooster.transform.position = spawnPos;
    }
    void Spawn_Score_Multiplier(Vector3 spawnPos)
    {
        GameObject scoreMultiplier = Spawner.instance.GetPooledPickUp("BlueScoreMultiplier(Clone)");
        scoreMultiplier.SetActive(true);
        scoreMultiplier.transform.position = spawnPos;
    }
    void SpawnFuel(Vector3 spawnPos)
    {
        GameObject fuel = Spawner.instance.GetPooledPickUp("Fuel(Clone)");
        fuel.SetActive(true);
        fuel.transform.position = spawnPos;
    }

    IEnumerator SpawnPickup()
    {
        while (continueSpawning)
        {
            spawnPos = new Vector3(Random.Range(130,250),Random.Range(50,150),player.transform.position.z + 600);
            int typeOfPickup = Random.Range(0, 8);
            if(typeOfPickup == 0 || typeOfPickup == 1 || typeOfPickup == 2)
                Spawn_Score_Boosters(spawnPos);
            if(typeOfPickup == 3 || typeOfPickup == 4)
                Spawn_Score_Multiplier(spawnPos);
            if(typeOfPickup == 5 || typeOfPickup == 6)
                Spawn_Speed_Boosters(spawnPos);
            if(typeOfPickup == 7)
                SpawnFuel(spawnPos);
            yield return spawnInterval;
        }
    }

    public void StartSpawningPickups()
    {
        continueSpawning = true;
        StartCoroutine(SpawnPickup());
    }
    public void StopSpawningPickups()
    {
        continueSpawning = false;
        StopCoroutine(SpawnPickup());
    }
}
