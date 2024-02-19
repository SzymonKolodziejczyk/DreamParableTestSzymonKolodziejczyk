using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    private HealthManager healthManager;
    public int damageAmount = 1;

    private void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with another agent
        if (collision.gameObject.CompareTag("Agent"))
        {
            // Reduce health of the current agent
            healthManager.TakeDamage(damageAmount);

            // Uncomment the line below if you want the other agent to take damage as well
            // collision.gameObject.GetComponent<HealthManager>().TakeDamage(damageAmount);
        }
    }
}