using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class movimetacaoBasica : MonoBehaviour
{
    [Header("Conf Player")]
    public float velocidade;
    private float movimentoHorizontal;
    private Rigidbody2D rbPlayer;
    public float forcaPulo;
    public Transform posicaoSensor;
    public bool sensor;
    private Animator anim;

    //criar uma variável ara verificar a direção 
    public bool verificarDirecaoPersonagem;

    //Configurando tiro
    public GameObject municao;
    public Transform posicaoTiro;
    public float velocidadeTiro;


    public int contadorVida;


   




    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verificarChao();

        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoHorizontal*velocidade, rbPlayer.velocity.y);


        //mudar direção do personagem

        if(movimentoHorizontal >0 && verificarDirecaoPersonagem ==true)
        {
            Flip();
        }if(movimentoHorizontal < 0 && verificarDirecaoPersonagem == false)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && sensor==true)
        {
            rbPlayer.AddForce(new Vector2(0, forcaPulo));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }

        anim.SetInteger("Run",(int)movimentoHorizontal);
        anim.SetBool("sensor", sensor);


        if (contadorVida <= 0)
        {
            contadorVida = 0;
        }
    }

    public void verificarChao()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.34f);
    }
    public void Flip()
    {
        verificarDirecaoPersonagem = !verificarDirecaoPersonagem;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y,transform.localScale.z);

        velocidadeTiro *= -1;

        municao.GetComponent<SpriteRenderer>().flipX = verificarDirecaoPersonagem;

    }
    public void Atirar()
    {
        GameObject temporario = Instantiate(municao);
        temporario.transform.position = posicaoTiro.position;
        temporario.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "vida")
        {
            Debug.Log("colidiu");
            contadorVida++;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "inimigo")
        {
            contadorVida--;
            Destroy(collision.gameObject);
           

        }
    }

}
