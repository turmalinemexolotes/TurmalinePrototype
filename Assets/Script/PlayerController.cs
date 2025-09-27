using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;         // velocidade do personagem
    public Camera mainCamera;            // referência da câmera

    private Vector3 targetPosition;      // onde o personagem deve ir
    private bool isMoving = false;       // se está se movendo ou não

    void Start()
    {
        targetPosition = transform.position; // começa parado
    }

    void Update()
    {
        HandleInput();   // ler cliques do mouse
        MovePlayer();    // mover o personagem
        HandleCamera();  // controlar a câmera
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(1)) // botão direito do mouse
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // pega posição clicada, mas mantém a altura do jogador
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                isMoving = true;
            }
        }
    }

    void MovePlayer()
    {
        if (!isMoving) return;

        // direção para o ponto alvo
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0; // garante que só gira no eixo horizontal

        // move suavemente até o ponto
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // gira suavemente para olhar na direção do movimento
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // para de mover quando chegar no ponto
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }


    void HandleCamera()
    {
        // posição fixa da câmera em cima do jogador
        Vector3 cameraOffset = new Vector3(0, 15, -10);
        mainCamera.transform.position = transform.position + cameraOffset;

        // câmera olha para o jogador
        mainCamera.transform.LookAt(transform.position);
    }
}