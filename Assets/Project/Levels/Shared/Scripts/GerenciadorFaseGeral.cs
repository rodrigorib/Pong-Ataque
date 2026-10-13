using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GerenciadorFaseGeral : MonoBehaviour
{
    public static GerenciadorFaseGeral instancia;

    [SerializeField]
    private GameObject panelVitoria;
    [SerializeField]
    private GameObject panelObjetivo;
    [SerializeField]
    private TextMeshProUGUI textTotalPontos;
    [SerializeField]
    private TextMeshProUGUI textPlacar;
    [SerializeField]
    private RawImage estrelaPlacarBaixo;
    [SerializeField]
    private RawImage estrelaPlacarMedio;
    [SerializeField]
    private RawImage estrelaPlacarAlto;
    [SerializeField]
    private GameObject panelGameOver;

    private int placar = 0;
    public int placarBaixo = 10;
    public int placarMedio = 15;
    public int placarAlto = 20;
    private Cronometro cronometro;
    [FormerlySerializedAs("FaseAtual")] //Permite dar um alias para a variável no inspetor. Renomear a variável não altera no inspetor.
    public int FaseAtual;

    public Vida vidaEsquerda;
    public Vida vidaDireita;

    public GameObject lancamentoCentral;
    public List<GameObject> pontosLancamento;

    void Awake()
    {
        Time.timeScale = 0f;
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        cronometro = GetComponent<Cronometro>();
        cronometro.FinalCronometragem += () => 
        {
            if (placar < placarBaixo)
                GameOver();
            else
                Vitoria();
        };

        vidaEsquerda.fimVidas += GameOver;
        vidaDireita.fimVidas += GameOver;

        panelObjetivo.SetActive(true);
    }

    public void Pontuar()
    {
        placar++;
        textPlacar.text = $"{placar}";
    }

    public void IniciarPartida()
    {
        Time.timeScale = 1f;
        panelObjetivo.SetActive(false);
        LancarBolaInicial();
    }

    public void Reiniciar()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(DelayLoadScene(sceneName));
    }

    public void FinalJogo()
    {
        StartCoroutine(DelayLoadScene("Final"));
    }

    private IEnumerator DelayLoadScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("Jogo Encerrado. \"Apenas Compilado\"");
    }

    public void TelaInicial()
    {
        StartCoroutine(DelayLoadScene("MainScene"));
    }

    public void ProximaFase()
    {
        int ultimaFaseLiberada = PlayerPrefs.GetInt("UltimaFaseLiberada", 1);
        int proximaFase = FaseAtual + 1;
        string sceneName = $"Fase{proximaFase.ToString("D2")}";

        if (ultimaFaseLiberada > FaseAtual + 1)
            StartCoroutine(DelayLoadScene(sceneName));
    }

    private void ZerarPlacar()
    {
        placar = 0;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
        ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.Derrota);
    }

    private void Vitoria()
    {
        Time.timeScale = 0f;
        panelVitoria.SetActive(true);
        textTotalPontos.text = $"{placar}";

        ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.Vitoria);
        string sceneName = SceneManager.GetActiveScene().name;

        if (placar >= placarAlto)
        {
            //3 estrelas
            SetaAlfa(estrelaPlacarBaixo, 1f);
            SetaAlfa(estrelaPlacarMedio, 1f);
            SetaAlfa(estrelaPlacarAlto, 1f);
            ConquistasAlcancadas(sceneName + "Conquistas", 3);
        }
        else if (placar >= placarMedio)
        {
            //2 estrelas
            SetaAlfa(estrelaPlacarBaixo, 1f);
            SetaAlfa(estrelaPlacarMedio, 1f);
            SetaAlfa(estrelaPlacarAlto, 0);
            ConquistasAlcancadas(sceneName + "Conquistas", 2);
        }
        else if(placar >= placarBaixo)
        {
            //1 estrela
            SetaAlfa(estrelaPlacarBaixo, 1f);
            SetaAlfa(estrelaPlacarMedio, 0);
            SetaAlfa(estrelaPlacarAlto, 0);
            ConquistasAlcancadas(sceneName + "Conquistas", 1);
        }

        LiberaProximaFase();
    }

    private void ConquistasAlcancadas(string fase, int quantidade)
    {
        int maxConquistasFase = PlayerPrefs.GetInt(fase, 0);

        if (maxConquistasFase < quantidade)
            PlayerPrefs.SetInt(fase, quantidade);
    }

    public void LancarBola()
    {
        GameObject posicaoLancar = PosicaoLancar();

        RespawnBolinha respawn = posicaoLancar.GetComponent<RespawnBolinha>();
        respawn.LancarBolinha();
    }

    public void LancarBolaInicial()
    {
        GameObject posicaoLancar = PosicaoLancar();
        RespawnBolinha respawn = posicaoLancar.GetComponent<RespawnBolinha>();

        respawn.fimAnimacao += () => {
            cronometro.IniciarContagem();
            ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.Rebatida);
        };

        respawn.LancarBolinha();
    }

    private GameObject PosicaoLancar()
    {
        int numeroLancar = UnityEngine.Random.Range(0, pontosLancamento.Count);
        GameObject posicaoLancar = pontosLancamento[numeroLancar];

        return posicaoLancar;
    }

    private void SetaAlfa(RawImage image, float alpha)
    {
        Color setaColor = image.color;
        setaColor.a = alpha;
        image.color = setaColor;
    }

    private void LiberaProximaFase()
    {
        int ultimaFaseLiberada = PlayerPrefs.GetInt("UltimaFaseLiberada",1);

        if (FaseAtual >= ultimaFaseLiberada)
            PlayerPrefs.SetInt("UltimaFaseLiberada", FaseAtual + 1);
    }
}
