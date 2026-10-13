using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConquistaFase : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasParent;
    [SerializeField]
    private GameObject imageConquista;
    [SerializeField]
    private GameObject imageConquistaVazia;
    [SerializeField]
    private string faseConquista;
    [SerializeField]
    private int maxConquistas = 3;
    [SerializeField]
    private float marginX = 1f;

    void Start()
    {
        CarregaConquistadasFase();
    }

    private void CarregaConquistadasFase()
    {
        int quantConquistas = PlayerPrefs.GetInt(faseConquista, 0);
        RectTransform rectBotaoTransform = gameObject.GetComponent<RectTransform>();
        float posicaoY = 0;

        float posicaoBaseX = rectBotaoTransform.anchoredPosition.x;
        int metadeX = maxConquistas / 2; //pega o valor inteiro
        int complementoX = maxConquistas % 2 > 0 ? 0 : 1;
        marginX = maxConquistas / 2 > 0 ? marginX : 0;
        float posicaoInicialX = - (metadeX * 2) - ((marginX * (maxConquistas - 1)) / 2) + complementoX;

        for (int i = 0; i < maxConquistas; i++)
        {
            GameObject conquista;

            if (quantConquistas > i)
                conquista = Instantiate(imageConquista, canvasParent.transform);
            else
                conquista = Instantiate(imageConquistaVazia, canvasParent.transform);

            RectTransform rectConquistaTransform = conquista.GetComponent<RectTransform>();
            posicaoY = DefinePosicaoY(rectBotaoTransform, rectConquistaTransform, posicaoY);
            
            float comprimentoConquista = rectConquistaTransform.rect.width;
            float posicaoX = posicaoBaseX + ((comprimentoConquista / 2) * posicaoInicialX);

            rectConquistaTransform.localPosition = new Vector2(posicaoX, posicaoY);

            if (i > maxConquistas - 1)
                marginX = 0;

            posicaoInicialX += 2 + marginX;
        }
    }

    private float DefinePosicaoY(RectTransform rectBotaoTransform, RectTransform rectConquistaTransform, float posicaoY)
    {
        float posicaoBotaoY = rectBotaoTransform.anchoredPosition.y;
        float alturaBotao = rectBotaoTransform.rect.height;
        float alturaConquista = rectConquistaTransform.rect.height;
        float marginY = 10f;

        posicaoY = posicaoBotaoY - (alturaBotao / 2) - (alturaConquista / 2) - marginY;

        return posicaoY;
    }
}
