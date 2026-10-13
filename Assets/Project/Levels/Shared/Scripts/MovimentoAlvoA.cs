using System.Collections;
using UnityEngine;

public class MovimentoAlvoA : MonoBehaviour
{
    public float velocidade = 5f;
    public float alturaMovimento = 2f;
    public bool parado = false;
    private float posicaoYInicial;
    public bool sentidoPositivo = true;

    void Start()
    {
        posicaoYInicial = transform.position.y;
    }

    void Update()
    {
        if (parado)
            return;

        float posicao = Mathf.PingPong(Time.time * velocidade, alturaMovimento);

        //SentidoPositivo determina se o movimento começará subindo ou descendo.
        posicao = sentidoPositivo ? posicao : alturaMovimento - posicao;
        posicao = posicao - (alturaMovimento / 2);

        gameObject.transform.position = new Vector2(transform.position.x, posicaoYInicial + posicao);
    }

}
