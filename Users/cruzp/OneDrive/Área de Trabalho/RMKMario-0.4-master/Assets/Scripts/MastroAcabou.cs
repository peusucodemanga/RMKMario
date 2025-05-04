using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MastroAcabou : MonoBehaviour
{
    public Transform bandeira,fundo,castelo;
    public GameObject telaFinal; 
    Animator animPlayer;
    public float velocidade = 6f;
    SoundSFX audioManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            StartCoroutine(MoverCoisas(bandeira,fundo.position));
            StartCoroutine(FinalDoJogo(other.transform)); 
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundSFX>();
            audioManager.PararBack();
            audioManager.PlaySFX(audioManager.FinalJogo);
        }
    }

    private IEnumerator FinalDoJogo(Transform player){
        player.GetComponent<Movimentacao1>().enabled=false;
        animPlayer = player.GetComponent<Animator>();
        //Audio
        //Animações
        animPlayer.SetBool("pulando",false);
        animPlayer.SetBool("mastro",true);
        AjeitandoMario(player);
        //Mario caindo
        yield return MoverCoisas(player,fundo.position);
        animPlayer.SetBool("mastro",false);
        yield return new WaitForSeconds(2f);
        //Mario indo pro ladinho e caindo
        player.GetComponent<Rigidbody2D>().gravityScale=1;
        yield return MoverCoisas(player,player.position+Vector3.right);
        yield return MoverCoisas(player,castelo.position);
        animPlayer.SetBool("andarFinal",false);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        Time.timeScale=0f;
        telaFinal.SetActive(true);
}
    private void AjeitandoMario(Transform player){
        player.GetComponent<Movimentacao1>().pulando=false;
        player.GetComponent<Rigidbody2D>().linearVelocity=Vector2.zero;
        player.GetComponent<Rigidbody2D>().gravityScale=0;
    }
    private IEnumerator MoverCoisas(Transform subject, Vector3 finalAnima){
        while(Vector3.Distance(subject.position,finalAnima)>0.125f){
            subject.position = Vector3.MoveTowards(subject.position,finalAnima,velocidade*Time.deltaTime);
            yield return null;
        }
        subject.position = finalAnima;
}

    public void MenuInicial(){
        Time.timeScale=1f;
        PlayerPrefs.SetInt("ContadorVida", 3);
        PlayerPrefs.SetInt("PontoM",0);
        SceneManager.LoadSceneAsync(0);
        
    }
    public void Reiniciar(){
        Time.timeScale=1f;
        PlayerPrefs.SetInt("ContadorVida", 3);
        PlayerPrefs.SetInt("PontoM",0);
        SceneManager.LoadSceneAsync(1);  
}
}

