using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenalidadeA : MonoBehaviour, IDano
{
    public void Dano(bool danoLadoEsquerdo)
    {
        if (danoLadoEsquerdo)
            GerenciadorFaseGeral.instancia.vidaEsquerda.CausarDano(1);
        else
            GerenciadorFaseGeral.instancia.vidaDireita.CausarDano(1);
    }
}
