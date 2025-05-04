using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jogo()
    {
        SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt("ContadorVida",3);
        PlayerPrefs.SetInt("PontoM",0);
        
    }
    public void Sair()
    {
        Application.Quit();
    }
}
