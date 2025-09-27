using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
