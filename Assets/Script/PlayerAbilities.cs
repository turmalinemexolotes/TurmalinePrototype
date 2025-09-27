using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform firePoint; // ponto de onde o projétil sai (pode ser na frente do player)
    public GameObject[] abilitiesPrefabs = new GameObject[4]; // QWER

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) UseAbility(0);
        if (Input.GetKeyDown(KeyCode.W)) UseAbility(1);
        if (Input.GetKeyDown(KeyCode.E)) UseAbility(2);
        if (Input.GetKeyDown(KeyCode.R)) UseAbility(3);
    }

    void UseAbility(int index)
    {
        if (abilitiesPrefabs[index] == null) return;

        // calcula direção da habilidade
        Vector3 mousePos = GetMouseWorldPosition();
        Vector3 direction = (mousePos - firePoint.position).normalized;

        // instancia e dispara o projétil
        GameObject abilityGO = Instantiate(abilitiesPrefabs[index], firePoint.position, Quaternion.identity);
        Ability ability = abilityGO.GetComponent<Ability>();
        if (ability != null)
        {
            ability.Launch(direction);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return transform.position + transform.forward;
    }
}