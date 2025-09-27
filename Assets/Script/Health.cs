using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthSlider; // arraste o Slider aqui

    [Header("Knockback Settings")]
    public float baseKnockbackForce = 5f; // for�a m�nima do empurr�o
    public float maxKnockbackMultiplier = 2f; // quanto pode aumentar com pouca vida
    private Rigidbody rb;

    void Start()
    {
        currentHealth = maxHealth;

        // configura o slider
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        rb = GetComponent<Rigidbody>();
    }

    // Recebe a posi��o do atacante
    public void TakeDamage(float amount, Vector3 attackerPosition)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // atualiza slider
        healthSlider.value = currentHealth;

        if (currentHealth > 0 && rb != null)
        {
            // calcula propor��o de vida perdida (quanto menos vida, maior o knockback)
            float healthPercent = currentHealth / maxHealth; // 1 = cheio, 0 = morto
            float knockbackForce = baseKnockbackForce * Mathf.Lerp(1f, maxKnockbackMultiplier, 1f - healthPercent);

            Vector3 knockDir = (transform.position - attackerPosition).normalized;
            knockDir.y = 0; // apenas horizontal
            rb.AddForce(knockDir * knockbackForce, ForceMode.Impulse);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Sobrecarga para dano que n�o aplica knockback
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // atualiza slider
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Explodiu!");
        Destroy(gameObject);
        SceneManager.LoadSceneAsync("GameOver");
    }

}
