using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    public float damagePerSecond = 10f;

    void OnTriggerStay(Collider other)
    {
        Health playerHealth = other.GetComponent<Health>();
        if (playerHealth != null)
        {
            // aplica dano contínuo, sem knockback
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}