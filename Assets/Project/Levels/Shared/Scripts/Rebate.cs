using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebate : MonoBehaviour
{
    public event Action RebateuBolinha;

    private BolinhaMovimento rebate;
    private bool rebatendo = false;
    public MovimentoRebatedor movimentoRebatedor;

    public GameObject setaVisual;
    public float velocidadeOscilacao = 100f;
    public float anguloMaximo = 45f;
    private float anguloAtual = 0;
    private float ladoRebatida;
    private bool rebatido;

    #region Eventos Inicialização

    private void Start()
    {
        ladoRebatida = transform.position.x < 0 ? 1f : -1f;
    }

    #endregion

    #region Métodos

    private IEnumerator TempoRebater()
    {
        SpriteRenderer seta = setaVisual.GetComponentInChildren<SpriteRenderer>();
        Color setaColor = seta.color;
        setaColor.a = 1f;
        seta.color = setaColor;

        yield return new WaitForSeconds(2);

        Debug.Log("Lançou por tempo");

        Rebateu();
    }
    private void OscilaSeta()
    {
        float variacao = Mathf.PingPong(Time.time * velocidadeOscilacao, anguloMaximo * 2);

        if (ladoRebatida == -1f)
            anguloAtual = variacao - anguloMaximo;
        else
            anguloAtual = variacao - anguloMaximo - 180f;

        setaVisual.transform.rotation = Quaternion.Euler(0, 0, anguloAtual);
    }

    private void Rebateu()
    {
        float anguloRadiano = (anguloAtual - (180f * ladoRebatida)) * Mathf.Deg2Rad;

        Vector2 direcao = new Vector2(Mathf.Cos(anguloRadiano), Mathf.Sin(anguloRadiano));
        rebate.Rebater(direcao);

        rebatendo = false;
        movimentoRebatedor.rebatendo = false;

        SpriteRenderer seta = setaVisual.GetComponentInChildren<SpriteRenderer>();
        Color setaColor = seta.color;
        setaColor.a = 0f;
        seta.color = setaColor;

        RebateuBolinha?.Invoke();

        //////Debug.Log($"Rebatedor esquerdo: {rebatedorAtual.rebatedorEsquerdo}");
    }

    #endregion
    #region Eventos

    private void Update()
    {
        rebatido = Input.GetKeyDown("space");

        OscilaSeta();

        if (rebatido && rebatendo)
        {
            //StopCoroutine("TempoRebater");
            StopAllCoroutines();
            //Debug.Log("Lançou por ação");
            Rebateu();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bola"))
        {
            Debug.Log("Tocou");
            rebate = collision.gameObject.GetComponent<BolinhaMovimento>();
            BolaDano bolaDano = collision.gameObject.GetComponent<BolaDano>();
            ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.PosseBola);
            Vector2 paredeAtingida = collision.contacts[0].normal;

            if (Math.Abs(paredeAtingida.x - (ladoRebatida * -1f)) > 0.1f)
            {
                return;
            }

            Debug.Log("Colisão X: " + collision.gameObject.transform.position.x);

            if (rebate.transform.position.x > 0)
            {
                rebate.transform.position = new Vector3(6.776f, rebate.transform.position.y, 0);
                bolaDano.danoLadoEsquerdo = false;
            }
            else
            {
                rebate.transform.position = new Vector3(-6.776f, rebate.transform.position.y, 0);
                bolaDano.danoLadoEsquerdo = true;
            }

            rebate.PararBola();
            movimentoRebatedor.rebatendo = true;
            rebatendo = true;

            StartCoroutine(TempoRebater());
        }
    }

    #endregion
}
