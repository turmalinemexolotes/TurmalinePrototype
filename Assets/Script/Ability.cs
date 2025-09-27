using UnityEngine;

public class Ability : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 10f;
    public float lifetime = 2f; // tempo antes de desaparecer
    public float pushForce = 5f; // força do empurrão

    private Vector3 direction;
    private float fixedY; // altura fixa do projétil

    public void Launch(Vector3 dir)
    {
        // trava a direção para ignorar o eixo Y
        dir.y = 0;
        direction = dir.normalized;

        // guarda a altura inicial
        fixedY = transform.position.y;

        Destroy(gameObject, lifetime); // destrói sozinho após lifetime segundos
    }

    void Update()
    {
        // move o projétil em linha reta
        transform.position += direction * speed * Time.deltaTime;

        // mantém a altura fixa
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        // Aplica dano
        Health targetHealth = other.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage, transform.position);
        }

        // Aplica empurrão
        Rigidbody targetRb = other.GetComponent<Rigidbody>();
        if (targetRb != null)
        {
            Vector3 pushDirection = (other.transform.position - transform.position).normalized;
            pushDirection.y = 0; // empurra só no plano horizontal
            targetRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }

        // Destrói o projétil ao atingir algo
        Destroy(gameObject);
    }
}