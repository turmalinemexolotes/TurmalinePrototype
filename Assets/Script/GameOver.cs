using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void Continuar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
