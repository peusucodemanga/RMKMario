using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject menu;
    public static bool pausa = false;
    void Awake()
    {
        menu.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausa==true) Continuar();
            else Pausa();
        }   
    }
    void Pausa()
    {
        menu.SetActive(true);
        Time.timeScale=0f;
        pausa=true;
    }
    public void Continuar(){
        menu.SetActive(false);
        Time.timeScale=1f;
        pausa=false;
    }
    public void Menu(){
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(1);

    }
}
