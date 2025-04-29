using Unity.VisualScripting;
using UnityEngine;

public class Movimentacao1 : MonoBehaviour
{
    Rigidbody2D rbMario;
    [SerializeField] float vel = 5f;
    [SerializeField] float forcaPulo = 8f;
    [SerializeField] bool pulando;
    [SerializeField] bool Chao = true;
    [SerializeField] bool Cano = true;

    [SerializeField] Transform chaoCheck;
    [SerializeField] LayerMask chaoLayer;

    Animator animPlayer;
    Animator animPPulo;

    private void Awake()
    {
        rbMario = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        animPPulo = GetComponent<Animator>();
    }

    private void Update()
    {
        Chao = Physics2D.Linecast(transform.position, chaoCheck.position, chaoLayer);
        Debug.DrawLine(transform.position, chaoCheck.position, Color.blue);    
        animPPulo.SetBool("pulando",!Chao);


        if (Input.GetButtonDown("Jump") && Chao){
            pulando = true;
        }
         else if (Input.GetButtonUp("Jump") && rbMario.linearVelocityY > 0) {
             rbMario.linearVelocity = new Vector2(rbMario.linearVelocity.x, rbMario.linearVelocity.y*0.5f);
            
        }
    }

    private void FixedUpdate()
    {
        Mover();
        MarioPula();
    }

    void Mover()
    {
        float x = Input.GetAxis("Horizontal");
        rbMario.linearVelocity = new Vector2(x * vel, rbMario.linearVelocity.y);
        animPlayer.SetFloat("velocidade",Mathf.Abs(x));
        if(x<0){
            transform.eulerAngles = new Vector2(0,180);
        }
        else if(x>0) transform.eulerAngles = new Vector2(0,0);

    }
    void MarioPula(){
        if (pulando){
            rbMario.linearVelocity = Vector2.up * forcaPulo;
            pulando = false;
        }
    
    }
}