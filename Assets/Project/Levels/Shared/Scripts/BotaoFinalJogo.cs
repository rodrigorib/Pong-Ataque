using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoFinalJogo : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Fase Atual: {GerenciadorFaseGeral.instancia.FaseAtual}");
        Debug.Log($"Max Fases: {DadoGlobal.MaxFases}");

        if (GerenciadorFaseGeral.instancia.FaseAtual >= DadoGlobal.MaxFases)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
