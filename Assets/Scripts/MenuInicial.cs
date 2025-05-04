using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jogo()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
