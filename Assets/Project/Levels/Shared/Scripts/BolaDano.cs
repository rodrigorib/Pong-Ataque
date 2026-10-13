using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDano : MonoBehaviour
{
	//Teste git
    public bool danoLadoEsquerdo = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDano dano = collision.gameObject.GetComponent<IDano>();

        if (dano != null)
            CausarDano(dano);
    }

    private void CausarDano(IDano dano)
    {
        dano.Dano(danoLadoEsquerdo);

        ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.BolaPerdida);
        GerenciadorFaseGeral.instancia.LancarBola();

        Destroy(gameObject);
    }
}
