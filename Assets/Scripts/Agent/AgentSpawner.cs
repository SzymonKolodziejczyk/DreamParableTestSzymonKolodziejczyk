using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject[] agentPrefabs; // Array of agent prefabs to spawn
    public Transform spawnPoint; // The spawn point for agents
    [Range(2, 6)]
    public float spawnDelay = 2f; // Delay between each spawn
    [Range(2, 60)]
    public int maxSpawnCount = 30; // Maximum number of spawned agents
    [Range(3, 5)]
    public int initialSpawnCount = 3; // Number of initial objects to spawn

    private int currentSpawnCount = 0; // Current number of spawned agents

    private void Start()
    {
        // Spawn initial objects
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnObject();
        }

        // Start spawning agents
        InvokeRepeating("SpawnAgent", spawnDelay, spawnDelay);
    }

    private void SpawnObject()
    {
        // Randomly select an agent prefab from the array
        GameObject randomAgentPrefab = agentPrefabs[Random.Range(0, agentPrefabs.Length)];

        // Calculate a random position on the x-z plane near the spawn point
        Vector3 randomPosition = new Vector3(spawnPoint.position.x + Random.Range(-5f, 5f), spawnPoint.position.y, spawnPoint.position.z + Random.Range(-5f, 5f));

        // Instantiate the agent at the random position
        GameObject spawnedAgent = Instantiate(randomAgentPrefab, randomPosition, spawnPoint.rotation);

        // Increase the current spawn count
        currentSpawnCount++;

        // Start a coroutine to check if the agent is destroyed
        StartCoroutine(CheckAgentDestroyed(spawnedAgent));
    }

    private void SpawnAgent()
    {
        // Check if the maximum spawn count has been reached
        if (currentSpawnCount >= maxSpawnCount)
        {
            return;
        }

        // Randomly select an agent prefab from the array
        GameObject randomAgentPrefab = agentPrefabs[Random.Range(0, agentPrefabs.Length)];

        // Instantiate the agent at the spawn point
        GameObject spawnedAgent = Instantiate(randomAgentPrefab, spawnPoint.position, spawnPoint.rotation);

        // Increase the current spawn count
        currentSpawnCount++;

        // Start a coroutine to check if the agent is destroyed
        StartCoroutine(CheckAgentDestroyed(spawnedAgent));
    }

    private IEnumerator CheckAgentDestroyed(GameObject agent)
    {
        // Wait until the agent is destroyed
        yield return new WaitUntil(() => agent == null);

        // Decrease the current spawn count
        currentSpawnCount--;
    }
}