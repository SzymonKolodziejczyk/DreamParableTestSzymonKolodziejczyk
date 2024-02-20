using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    private HealthManager healthManager;
    public int damageAmount = 1;
    private bool canTakeDamage = true;
    public float damageCooldown = 1f;

    private void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with another agent and can take damage
        if (collision.gameObject.CompareTag("Agent") && canTakeDamage)
        {
            // Reduce health of the current agent
            healthManager.TakeDamage(damageAmount);

            // Uncomment the line below if you want the other agent to take damage as well
            // collision.gameObject.GetComponent<HealthManager>().TakeDamage(damageAmount);

            // Start the cooldown coroutine
            StartCoroutine(DamageCooldown());
        }
    }

    private IEnumerator DamageCooldown()
    {
        // Disable taking damage
        canTakeDamage = false;

        // Wait for the cooldown duration
        yield return new WaitForSeconds(damageCooldown);

        // Enable taking damage again
        canTakeDamage = true;
    }
}