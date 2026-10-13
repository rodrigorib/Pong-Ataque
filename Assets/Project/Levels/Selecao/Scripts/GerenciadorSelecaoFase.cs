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
}
