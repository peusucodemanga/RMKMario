using UnityEngine;

public class Espinhos : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")) {
        Movimentacao1 movimentacao = collision.gameObject.GetComponent<Movimentacao1>();
        movimentacao.Morte();}
    }

}
