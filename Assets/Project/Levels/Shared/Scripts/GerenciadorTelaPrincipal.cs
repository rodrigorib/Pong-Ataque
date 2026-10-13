using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadoTelaPrincipal : MonoBehaviour
{
    public static GerenciadoTelaPrincipal instancia;

    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Fase01");
    }

    public void SelecionarFase()
    {
        SceneManager.LoadScene("Selecao");
    }

    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("Jogo Encerrado. \"Apenas Compilado\"");
    }
}
