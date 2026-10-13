using System;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject prefabVida;
    public GameObject prefabVidaPerdida;
    public bool acrescentaEsquerda;
    public float distanciaEntreVidas;

    private int vidaAtual;
    public int vidaMaxima;
    private List<GameObject> listaVidas;

    public event Action fimVidas;

    private void Start()
    {
        vidaAtual = vidaMaxima;
        PrencherListaVidas();
    }

    public int PontosDeVida()
    {
        return vidaAtual;
    }

    public int AdicionarVida(int quantidadeVida)
    {
        vidaAtual += (vidaAtual + quantidadeVida) > vidaMaxima ? 0 : quantidadeVida;
        AtualizarExibicaoVida();

        return PontosDeVida();
    }

    public int CausarDano(int quantidadeVida)
    {
        vidaAtual -= (vidaAtual - quantidadeVida) < 0 ? 0: quantidadeVida;
        AtualizarExibicaoVida();

        if (vidaAtual == 0)
            fimVidas?.Invoke();

        return vidaAtual;
    }

    private void AtualizarExibicaoVida()
    {
        for (int i = 0; i < vidaMaxima; i++)
        {
            if (vidaAtual > i)
            {
                GameObject itemVida = listaVidas[i];
                GameObject itemVidaGanha = Instantiate(prefabVida, gameObject.transform);
                itemVidaGanha.transform.position = itemVida.transform.position;
                Destroy(itemVida);
                listaVidas[i] = itemVidaGanha;
            }
            else
            {
                GameObject itemVida = listaVidas[i];
                GameObject itemVidaPerdida = Instantiate(prefabVidaPerdida, gameObject.transform);
                itemVidaPerdida.transform.position = itemVida.transform.position;
                Destroy(itemVida);
                listaVidas[i] = itemVidaPerdida;
            }
        }
    }

    public void PrencherListaVidas()
    { 
        listaVidas = new List<GameObject>();
        float posicaoVidaY = transform.position.y;
        float comprimentoVida = prefabVida.GetComponent<SpriteRenderer>().bounds.size.x;
        float posicaoVidaX = transform.position.x;
        float fatorDirecao = acrescentaEsquerda ? -1f : 1f;

        for (int i = 0; i < vidaMaxima; i++)
        {
            GameObject novaVida = Instantiate(prefabVida, gameObject.transform);
            novaVida.transform.position = new Vector2(posicaoVidaX, posicaoVidaY);
            listaVidas.Add(novaVida);

            posicaoVidaX += (comprimentoVida + distanciaEntreVidas) * fatorDirecao ;
        }
    }

    public void AlterarPlacarVida()
    {
        //Mudar a imagem das vidas de acordo com a quantidade de vidas em relação ao total
    }
}
