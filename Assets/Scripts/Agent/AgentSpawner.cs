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
    public int initialSpawnCount = 3; // Number of initial agents to spawn
    public string[] possibleNames; // Array of possible names for agents
    private int currentSpawnCount = 0; // Current number of spawned agents

    private void Start()
    {
        // Spawn initial agents
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnAgent();
        }

        // Start spawning agents
        StartCoroutine(SpawnAgentsRoutine());
    }

    private IEnumerator SpawnAgentsRoutine()
    {
        while (currentSpawnCount < maxSpawnCount)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnAgent();
        }
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

        // Calculate a random position on the x-z plane near the spawn point
        Vector3 randomPosition = spawnPoint.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));

        // Instantiate the agent at the random position
        GameObject spawnedAgent = Instantiate(randomAgentPrefab, randomPosition, spawnPoint.rotation);

        // Assign a random name to the spawned agent
        string randomName = GetUniqueRandomName();
        spawnedAgent.name = randomName;

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

    private string GetUniqueRandomName()
    {
        // Shuffle the possible names array
        for (int i = 0; i < possibleNames.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, possibleNames.Length);
            string temp = possibleNames[i];
            possibleNames[i] = possibleNames[randomIndex];
            possibleNames[randomIndex] = temp;
        }

        // Find a unique name that hasn't been used yet
        foreach (string name in possibleNames)
        {
            if (!GameObject.Find(name))
            {
                return name;
            }
        }

        // If all names are already used, return a default name
        return "Agent";
    }
}