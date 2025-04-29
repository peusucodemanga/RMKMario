using UnityEngine;

public class Goomba : MonoBehaviour
{
    Rigidbody2D rbGoomba;
    [SerializeField] float velocidade = 1f;
    [SerializeField] Transform p1;
    [SerializeField] LayerMask canoLayer; 
    [SerializeField] float distancia = 0.2f;
    Animator MorteG,GoombaWalk;
    BoxCollider2D ColisorG;
    [SerializeField]bool MortoM = false;
    void Awake()
    {
        rbGoomba = GetComponent<Rigidbody2D>();
        MorteG = GetComponent<Animator>();
        ColisorG = GetComponent<BoxCollider2D>();
        GoombaWalk = GetComponent<Animator>();
    }
        private void Start()
    {
        MortoM=false;

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
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag =="Player"){
            if(transform.position.y+0.5f<collision.transform.position.y && MortoM==false)
        {   collision.GetComponent<Rigidbody2D>().linearVelocity=Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            MorteG.SetTrigger("MorteG");
            velocidade=0;
            Destroy(gameObject,0.3f); 
            ColisorG.enabled=false;
        }
            else {
            MortoM=true;
            ColisorG.enabled=false;
            FindFirstObjectByType<Movimentacao1>().Morte();
            Goomba[] goomba = FindObjectsByType<Goomba>(FindObjectsSortMode.None);
            //faz um for e enche todos os goombas com velocidade 0 paradinhos pra eles nao se mexerem quando tu morre
            for(int j = 0;j<goomba.Length;j++){
                goomba[j].velocidade=0;
                goomba[j].GoombaWalk.speed = 0;
            }
        }

    }

    }
}