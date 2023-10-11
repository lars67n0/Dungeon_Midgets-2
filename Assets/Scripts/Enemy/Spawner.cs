using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject BigswarmerPrefab;

    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float initialSwarmerInterval = 2f;

    [SerializeField]
    private float initialBigSwarmerInterval = 3f;

    [SerializeField]
    private float durationToIncreaseSpawnRate = 1f;

    private float currentSwarmerInterval;
    private float currentBigSwarmerInterval;

    // Start is called before the first frame update
    void Start()
    {
        currentSwarmerInterval = initialSwarmerInterval;
        currentBigSwarmerInterval = initialBigSwarmerInterval;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float elapsedTime = 0f;

        while (elapsedTime < durationToIncreaseSpawnRate)
        {
            yield return new WaitForSeconds(currentSwarmerInterval);
            GameObject newSwarmer = Instantiate(swarmerPrefab, GetRandomSpawnPosition(), Quaternion.identity);

            yield return new WaitForSeconds(currentBigSwarmerInterval);
            GameObject newBigSwarmer = Instantiate(BigswarmerPrefab, GetRandomSpawnPosition(), Quaternion.identity);

            // Increase the spawn rate gradually
            float timeIncrement = Time.deltaTime;
            elapsedTime += timeIncrement;
            currentSwarmerInterval = Mathf.Lerp(initialSwarmerInterval, initialSwarmerInterval / 2f, elapsedTime / durationToIncreaseSpawnRate);
            currentBigSwarmerInterval = Mathf.Lerp(initialBigSwarmerInterval, initialBigSwarmerInterval / 2f, elapsedTime / durationToIncreaseSpawnRate);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-6f, 6f), 0);
    }
}

