using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentSelection : MonoBehaviour
{
    public GameObject infoOverlay; // Reference to the information overlay UI
    public TextMeshProUGUI nameText; // Reference to the UI text field for the agent name
    public TextMeshProUGUI hpText; // Reference to the UI text field for the agent HP
    public GameObject agentSelectionCircle; // Reference to the agent you want to appear/disappear

    private bool isSelected = false; // Flag to track if the agent is selected
    private HealthManager healthManager; // Reference to the HealthManager component

    private void Start()
    {
        healthManager = GetComponent<HealthManager>(); // Get the reference to the HealthManager component
    }

    private void Update()
    {
        // Check for mouse clicks outside the agent agent
        if (isSelected && Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast and check if it hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit agent is not the agent itself
                if (hit.transform.gameObject != gameObject)
                {
                    // Deselect the agent and hide the information overlay
                    isSelected = false;
                    infoOverlay.SetActive(false);

                    // Hide the circle agent
                    agentSelectionCircle.SetActive(false);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        // Toggle the selection state
        isSelected = !isSelected;

        // Show or hide the information overlay based on the selection state
        infoOverlay.SetActive(isSelected);

        // Show or hide the circle agent based on the selection state
        agentSelectionCircle.SetActive(isSelected);

        // Update the UI text fields with the agent name and HP
        if (isSelected)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // Get the agent name and current health
        string agentName = gameObject.name;
        int currentHealth = healthManager.currentHealth;

        // Update the UI text fields
        nameText.text = "Name: " + agentName;
        hpText.text = "HP: " + currentHealth.ToString();
    }
}