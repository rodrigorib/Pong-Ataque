using UnityEngine;

public class BolaFora : MonoBehaviour, IDano
{
    [SerializeField]
    private bool placarEsquerda;

    public void Dano(bool danoLadoEsquerdo)
    {
        if (placarEsquerda)
            GerenciadorFaseGeral.instancia.vidaEsquerda.CausarDano(1);
        else
            GerenciadorFaseGeral.instancia.vidaDireita.CausarDano(1);
    }
}
