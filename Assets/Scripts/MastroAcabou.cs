using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MastroAcabou : MonoBehaviour
{
    public Transform bandeira,fundo,castelo;
    public GameObject telaFinal; 
    public float velocidade = 6f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            StartCoroutine(MoverCoisas(bandeira,fundo.position));
            StartCoroutine(FinalDoJogo(other.transform));    
        }
    }

    private IEnumerator FinalDoJogo(Transform player){
        player.GetComponent<Movimentacao1>().enabled=false;
        player.GetComponent<Rigidbody2D>().linearVelocity=Vector2.zero;
        player.GetComponent<Rigidbody2D>().gravityScale=0;
        //Mario caindo
        yield return MoverCoisas(player,fundo.position);
        yield return new WaitForSeconds(1f);
        //Mario indo pro ladinho e caindo
        player.GetComponent<Rigidbody2D>().gravityScale=1;
        yield return MoverCoisas(player,player.position+Vector3.right);
        yield return MoverCoisas(player,castelo.position);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        Time.timeScale=0f;
        telaFinal.SetActive(true);
}
    private IEnumerator MoverCoisas(Transform subject, Vector3 finalAnima){
        while(Vector3.Distance(subject.position,finalAnima)>0.125f){
            subject.position = Vector3.MoveTowards(subject.position,finalAnima,velocidade*Time.deltaTime);
            yield return null;
        }
        subject.position = finalAnima;
}

    public void Reiniciar(){
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(0);  
}
    public void MenuInicial(){
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(1);
        
    }
}

