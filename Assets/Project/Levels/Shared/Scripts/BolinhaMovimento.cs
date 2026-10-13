using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BolinhaMovimento : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D rb;
    private bool rebatendo = false;
    [SerializeField]
    private PhysicsMaterial2D materialRebote;
    [SerializeField]
    private PhysicsMaterial2D materialSemRebote;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LancarBola();
    }

    private void LancarBola()
    {
        float x = transform.position.x >= 0 ? 1f : -1f;
        float y = UnityEngine.Random.Range(0, 2) == 0 ? -0.5f : 0.5f;
        Vector2 direcao = new Vector2(x, y).normalized;

        MovimentarBola(direcao);
    }

    public void Rebater(Vector2 direcao)
    {
        MovimentarBola(direcao);
        ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.Rebatida);
    }

    public void PararBola()
    {
        rb.velocity = Vector2.zero;
    }

    private void MovimentarBola(Vector2 direcao)
    {
        rb.velocity = direcao * velocidade;
    }
}
