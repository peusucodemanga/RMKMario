using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimentacao1 : MonoBehaviour
{
    Rigidbody2D rbMario;
    [SerializeField] float vel = 5f;
    [SerializeField] float forcaPulo = 8f;
    [SerializeField] bool pulando;
    [SerializeField] bool Chao = true;
    [SerializeField] Transform chaoCheck;
    [SerializeField] LayerMask chaoLayer;

    Animator animPlayer,animPPulo,animMorte;
    [SerializeField]bool MortoM = false;
    BoxCollider2D MarioColisor;
    bool MortoM1;

    private void Awake()
    {
        rbMario = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        animPPulo = GetComponent<Animator>();
        animMorte = GetComponent<Animator>();
        MarioColisor = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        MortoM=false;

    }

    private void Update()
    {
        if (MortoM) return;

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
        if(MortoM) return;
 
            float x = Input.GetAxis("Horizontal");
            rbMario.linearVelocity = new Vector2(x * vel, rbMario.linearVelocity.y);
            animPlayer.SetFloat("velocidade",Mathf.Abs(x));
            if(x<0){
                transform.eulerAngles = new Vector2(0,180);
            }
            else if(x>0) transform.eulerAngles = new Vector2(0,0);
            }
        
    void MarioPula(){
        if(MortoM)return;

            if (pulando){
                rbMario.linearVelocity = Vector2.up * forcaPulo;
                pulando = false;
            }
        
    }
    public void Morte(){
        StartCoroutine(MorteCoroutine());
    }

        IEnumerator MorteCoroutine(){
    if(!MortoM){
        //Fazendo ele ficar com a animacao certa :3
        animMorte.SetTrigger("MorteM");
        MortoM=true;
        yield return new WaitForSeconds(0.5f);
        //Fazeno o caba ficar parado
        rbMario.linearVelocity = Vector2.zero;
        //Paizao aí tu ta fzendo o caba ficar invisivel/intangivel
        MarioColisor.isTrigger=true;
        //Olha o pulinho do pai
        rbMario.AddForce(Vector2.up*15f,ForceMode2D.Impulse);
        Invoke("Reinicia",2.5f);
    }
    

}
    void Reinicia(){
        SceneManager.LoadScene("Inicio");
    }

}