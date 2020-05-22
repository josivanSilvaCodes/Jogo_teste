using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    GameObject block_8; // Uma variável do tipo Objeto instancia de GameObject
    GameObject block_16; // Outra instancia de GameObject para representar o bloco de 16
    GameObject[] array_go; // Array / Vetor para guardar os blocos de  8 e 16

    float px; // Variável do tipo primitiva para guardar um n° real
    float py; // Outra variável para guardar um n° real para guardar a altura do bloco
    float sp; // Outra variável para guardar um n° real do espaço entre os blocos

    void Start() // O método Start é chamado assim que o jogo inicia, uma única vez
    {
        px = 0; // inicializando a vaiável do tipo real/float com 0
        py = 0.0f; // inicializando a vaiável do tipo real/float como 0.0f
        sp = 0;
        array_go = new GameObject[5];

        //Carregando os objetos da pasta Resources.Load para instanciar os objetos dos blocos
        block_8 = Instantiate(Resources.Load("Block_8", typeof(GameObject))) as GameObject;
        block_16 = Instantiate(Resources.Load("Block_16", typeof(GameObject))) as GameObject;

        array_go[0] = block_8; // colocando o primeiro bloco no Array, apra facilitar
        array_go[0].transform.position = new Vector2(px, py); // setando a posição do 1° bloco

        // Estrutura for para visitar todos os indices do Array e ir colocando os blocos corretos
        // Temos que colocar os blocos corretos nas posições corretas, lembre-se disso...
        // ISSO GARANTE QUE TENHAMOS UMA VARIEDADE DO TIPO DE BLOCOS NA TELA, PARA NÃO FICAR TÃO REPETITIVO
        // EM JOGOS DIGITAIS TUDO QUE FOR MUITO REPETITIVO FICA PREVISÍVEL E CHATO, JOGO É PARA DIVERTIR...
        for (int i = 1; i < array_go.Length; i++)
        {
            int t = Random.Range(1, 6); // Sorteia um valor inteiro aleatório entre 1 e 6
            sp = Random.Range(0, 2);   // Sorteia um espaço entre 0 (nenhum) e 2 (unidades de espaçamento)
            if (t % 2 == 0) // Se o valor entre 1 e 6 for par
            {
                // Coloca o novo bloco na pos. [i] atual do Array, mas o posicionamento depende da larg. do anterior
                // Para verificarmos a posição do bloco anterior acessamos o anterior com [i-1]
                // COM VALOR SORTEADO SENDO PAR VAMOS ADICIONAR UM BLOCO DE LARGURA 8, o anterior pode ser 8 ou 16.
                array_go[i] = Instantiate(Resources.Load("Block_8", typeof(GameObject))) as GameObject;
                if (array_go[i - 1].tag == "Block_8") // Se o bloco anterior for de largura 8
                {
                    px += 1.1f + sp; // Então soma 1.1f (do bloco 8) na larg., + o espaço e coloca o novo bloco
                    array_go[i].transform.position = new Vector2(px, py); // posiciona na larg. e alt. correta
                }
                if (array_go[i - 1].tag == "Block_16") // Se o bloco anterior for de largura 16
                {
                    px += 1.65f + sp; // Então soma 1.65f (do bloco 16) mais o espaço e coloca o novo bloco
                    array_go[i].transform.position = new Vector2(px, py); // posiciona na larg. e alt. correta
                }
            }
            else // Se o valor entre 1 e 6 for ímpar
            {
                // COM VALOR SORTEADO SENDO ÍMPAR VAMOS ADICIONAR UM BLOCO DE LARG. 8, o anterior pode ser 8 ou 16.
                array_go[i] = Instantiate(Resources.Load("Block_16", typeof(GameObject))) as GameObject;
                if (array_go[i - 1].tag == "Block_8") // Se o bloco anterior for de largura 8
                {
                    px += 1.65f + sp; // Então soma 1.65f (do bloco 8) na larg., + o espaço e coloca o novo bloco
                    array_go[i].transform.position = new Vector2(px, py); // posiciona na larg. e alt. correta
                }
                if (array_go[i - 1].tag == "Block_16")
                {
                    px += 2.15f + sp; // Então soma 1.65f (do bloco 8) na larg., + o espaço e coloca o novo bloco
                    array_go[i].transform.position = new Vector2(px, py); // posiciona na larg. e alt. correta
                }
            }

            if (i == array_go.Length - 1 && array_go[array_go.Length - 2].tag == "Block_8")
            {
                array_go[i] = Instantiate(Resources.Load("Wall_End", typeof(GameObject))) as GameObject;
                px += 0.56f;
                py += 3.65f;
                array_go[i].transform.position = new Vector2(px, py);
            }
            if (i == array_go.Length - 1 && array_go[array_go.Length - 2].tag == "Block_16")
            {
                array_go[i] = Instantiate(Resources.Load("Wall_End", typeof(GameObject))) as GameObject;
                px += 0.90f;
                py += 3.65f;
                array_go[i].transform.position = new Vector2(px, py);
            }
        }//Fim do For
    }

    // Update is called once per frame
    void Update() // O método Update é chaamdo uma vez a cada atualização do Frame
    {

    }
}
