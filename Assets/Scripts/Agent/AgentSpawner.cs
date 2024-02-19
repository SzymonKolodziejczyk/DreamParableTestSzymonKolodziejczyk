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

    private int currentSpawnCount = 0; // Current number of spawned agents

    private void Start()
    {
        // Start spawning agents
        InvokeRepeating("SpawnAgent", 0f, spawnDelay);
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