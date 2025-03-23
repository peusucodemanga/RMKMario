using UnityEngine;

public class Movimentacao1 : MonoBehaviour
{
    Rigidbody2D rbMario;
    [SerializeField] float vel = 5f;
    private void Awake()
    {
        rbMario = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    void Mover()
    {
        float x = Input.GetAxis("Horizontal");
        rbMario.linearVelocity = new Vector2(x * vel, rbMario.linearVelocity.y);
        if(x<0){
            transform.eulerAngles = new Vector2(0,180);
        }
        else{
            transform.eulerAngles = new Vector2(0,0);
        }
    }
}