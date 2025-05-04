using UnityEngine;
using UnityEngine.Events;

public class BlocosDestrutivos : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;
    SoundSFX audioManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            //Pego a colisão de baixo com o Y, depois eu coloco onde no X pro lado esquerdo e direito eu quero que ele verifique se atingiu
            if(    collision.transform.position.y < transform.position.y - 0.5f &&
                   collision.transform.position.x < transform.position.x + 0.6f &&
                   collision.transform.position.x > transform.position.x - 0.6f){
                Destroy(gameObject);
                _hit?.Invoke();
                audioManager.PlaySFX(audioManager.BlocoQuebrando);
            }
        }
    }
    private void Awake()
    {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundSFX>();
    }
    [SerializeField] private GameObject _object;
    public void Spawn(){
        Instantiate(_object,transform.position,Quaternion.identity);
    }
}