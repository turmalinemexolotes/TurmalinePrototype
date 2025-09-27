using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // pega a câmera principal
    }

    void LateUpdate()
    {
        // faz a barra sempre olhar para a câmera
        transform.forward = mainCamera.transform.forward;
    }
}
