using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoFase : MonoBehaviour
{
    private void Start()
    {
        if (GerenciadorFaseGeral.instancia.FaseAtual >= DadoGlobal.MaxFases)
            gameObject.SetActive(false);
    }
}
