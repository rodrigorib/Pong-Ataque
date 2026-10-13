using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFase : MonoBehaviour
{
    public int faseBotao = 0;

    void Start()
    {
        Button botao = GetComponent<Button>();
        int ultimaFaseLiberada = PlayerPrefs.GetInt("UltimaFaseLiberada", 1);

        if (ultimaFaseLiberada >= faseBotao)
            botao.interactable = true;
        else
            botao.interactable = false;
    }
}
