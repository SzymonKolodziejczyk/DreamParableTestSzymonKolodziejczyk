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

    private bool isSelected = false; // Flag to track if the agent is selected

    private void OnMouseDown()
    {
        // Toggle the selection state
        isSelected = !isSelected;

        // Show or hide the information overlay based on the selection state
        infoOverlay.SetActive(isSelected);

        // Update the UI text fields with the agent name and HP
        if (isSelected)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // Get the agent name and HP
        string agentName = gameObject.name;
        int agentHP = GetComponent<HealthManager>().currentHealth;

        // Update the UI text fields
        nameText.text = "Name: " + agentName;
        hpText.text = "HP: " + agentHP.ToString();
    }
}