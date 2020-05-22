using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Variáveis simples do C# chamam tipos primitivos
    public float speed;        // Número real para guardar uma velocidade
    public float jumpForce;    // Número real para guardar uma componente de Força na direção Y
    public bool isJumping = false; // Variável Booleana para saber se o jogador está pulando ou no chão

    // variáveis complexas, são objetos 
    private Rigidbody2D rb; //Esse objeto é do tipo RigidBody2D e está relacionado com um componente do jogo

    void Start() // O método Start é chamado assim que o jogo inicia, uma única vez
    {
        rb = GetComponent<Rigidbody2D>(); // Quando inicia já pega o componente e traz para o código
    }

    void Update() // O método Update é chaamdo uma vez a cada atualização do Frame
    {
        rb.velocity = new Vector2(speed, rb.velocity.y); // Coloca o valor da velocidade no objeto

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) // Verifica se é para pular
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Então pula
            isJumping = true; // Avisa/informa que está pulando
        }
    }

    // Esse método é chamado quando 2 colliders se tocam
    private void OnCollisionEnter2D(Collision2D collision) // Nesse caso o código é do PLayer e o Collider também
    {
        if (collision.gameObject.layer == 8) // Verifica se o outro Collider é do chão (blocos)
        {
            isJumping = false; // Então avisa que está no chão e não mais pulando.
        }

        if (collision.gameObject.tag == "wall_end") // Verifica se o outro Collider é do chão (blocos)
        {
            Invoke("TrocarCena", 0.5f);
        }
    }

    void TrocarCena()
    {
        SceneManager.LoadScene("Cena2");
    }


}
