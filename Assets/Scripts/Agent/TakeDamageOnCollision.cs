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
            // Reduce health of both agents
            healthManager.TakeDamage(damageAmount);
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damageAmount);
        }
    }
}