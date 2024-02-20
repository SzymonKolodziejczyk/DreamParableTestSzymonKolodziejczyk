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
    public GameObject UnitSelection; // Reference to the agent you want to appear/disappear

    private bool isSelected = false; // Flag to track if the agent is selected
    private HealthManager healthManager; // Reference to the HealthManager component

    private void Start()
    {
        healthManager = GetComponent<HealthManager>(); // Get the reference to the HealthManager component

        if (infoOverlay == null)
        {
            Debug.LogWarning("Info Overlay reference not assigned.");
        }

        if (nameText == null)
        {
            Debug.LogWarning("Name Text reference not assigned.");
        }

        if (hpText == null)
        {
            Debug.LogWarning("HP Text reference not assigned.");
        }

        if (UnitSelection == null)
        {
            Debug.LogWarning("Unit Selection reference not assigned.");
        }
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
                    UnitSelection.SetActive(false);
                }
            }
        }
    }

    private void LateUpdate()
    {
        // Update the UI text fields if the agent is selected
        if (isSelected)
        {
            UpdateUI();
        }
    }

    private void OnMouseDown()
    {
        // Toggle the selection state
        isSelected = !isSelected;

        // Show or hide the information overlay based on the selection state
        infoOverlay.SetActive(isSelected);

        // Show or hide the circle agent based on the selection state
        UnitSelection.SetActive(isSelected);

        // Update the UI text fields with the agent name
        if (isSelected)
        {
            nameText.text = "Name: " + gameObject.name;
        }
    }

    private void UpdateUI()
    {
        // Get the current health value
        int currentHealth = healthManager.currentHealth;

        // Update the UI text field for HP
        hpText.text = "HP: " + currentHealth.ToString();
    }
}