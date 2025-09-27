using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject abilityPrefab; // Para magias que criam algo (ex: explosão)
    public Transform abilitySpawnPoint; // Ponto de origem da magia (ex: frente do player)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastImmediateAbility();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PrepareTargetedAbility();
        }
    }

    void CastImmediateAbility()
    {
        // Exemplo: Explosão em volta do player
        GameObject ability = Instantiate(abilityPrefab, transform.position, Quaternion.identity);
        Debug.Log("Usou habilidade imediata (Q)");
    }

    void PrepareTargetedAbility()
    {
        // Aqui só prepara a magia
        Debug.Log("Habilidade engatilhada (W) - clique para lançar");
    }
}
