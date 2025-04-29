using UnityEngine;

public class Goomba : MonoBehaviour
{
    Rigidbody2D rbGoomba;
    [SerializeField] float velocidade = 1f;
    [SerializeField] Transform p1;
    [SerializeField] LayerMask canoLayer; 
    [SerializeField] float distancia = 0.2f;

    void Awake()
    {
        rbGoomba = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rbGoomba.linearVelocity = new Vector2(velocidade, rbGoomba.linearVelocity.y);

        Vector2 direcao = velocidade > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(p1.position, direcao, distancia, canoLayer);

        if(hit.collider != null)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            velocidade *= -1;
        }
    }
}