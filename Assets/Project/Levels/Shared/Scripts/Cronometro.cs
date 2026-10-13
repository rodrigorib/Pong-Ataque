using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI textTimer;

    public float tempo = 10f;
    private float tempoRestante;
    private bool fimContagem = false;
    private bool pausaContagem = true;
    public int segundosContagemFinal = 10;

    public event Action FinalCronometragem;

    private void Start()
    {
        tempoRestante = tempo;
        segundosContagemFinal = 10;
    }

    private void Update()
    {
        if (!fimContagem)
        {
            if (tempoRestante > 0 && !pausaContagem)
            {
                tempoRestante -= Time.deltaTime;

                if (tempoRestante <= 0)
                {
                    tempoRestante = 0;
                    fimContagem = true;

                    FinalCronometragem?.Invoke();
                }

                int segundos = Mathf.FloorToInt(tempoRestante);
                string tempo = string.Format("{0:00}", segundos);
                textTimer.text = $"{tempo}";

                if (segundosContagemFinal > segundos)
                {
                    StartCoroutine(PiscaContagem());
                    segundosContagemFinal = segundos;
                }
            }
        }
    }

    public void IniciarContagem()
    {
        fimContagem = false;
        pausaContagem = false;
    }

    public void PausarContagem()
    {
        pausaContagem = true;
    }

    public void RetomarContagem()
    {
        pausaContagem = false;
    }

    public void ReiniciarContagem()
    {
        tempoRestante = tempo;
        fimContagem = false;
    }

    private IEnumerator PiscaContagem()
    {
        textTimer.color = Color.yellow;

        yield return new WaitForSeconds(0.5f);

        textTimer.color = Color.white;
    }
}
