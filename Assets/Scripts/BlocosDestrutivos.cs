using UnityEngine;
using UnityEngine.Events;

public class BlocosDestrutivos : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            if(transform.position.y+0.5f>collision.transform.position.y && transform.position.x+0.1f>collision.transform.position.x) {
                Destroy(gameObject);
                _hit?.Invoke();
        }
    }
    
}
    [SerializeField] private GameObject _object;
    public void Spawn(){
        Instantiate(_object,transform.position,Quaternion.identity);
    }
}