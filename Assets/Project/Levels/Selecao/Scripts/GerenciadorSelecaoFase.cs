using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciadorSelecaoFase : MonoBehaviour
{
    private Dictionary<int, string> sceneList;

    private void Start()
    {
        sceneList = new Dictionary<int, string>();
        sceneList.Add(900, "MainScene");
        sceneList.Add(901, "Selecao");
        sceneList.Add(1, "Fase01");
        sceneList.Add(2, "Fase02");
        sceneList.Add(3, "Fase03");

        //PlacarFase01();

        //GameObject estrela = Instantiate(image01, canvasParent.transform);
        //RectTransform rectTransform = estrela.GetComponent<RectTransform>();

        //rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y + 10f);
    }

    public void LoadFase(int fase)
    {
        string nomeScene = sceneList[fase];

        StartCoroutine(DelayLoadScene(nomeScene));
    }

    private IEnumerator DelayLoadScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }

    //private void PlacarFase01()
    //{
    //    int placarFase01 = PlayerPrefs.GetInt("Fase01Conquistas", 0);

    //    textPlacarFase01.text = placarFase01.ToString();
    //}

    private void FasesHabilitadas()
    {

    }
}
