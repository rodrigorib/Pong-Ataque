using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DanoAlvo : MonoBehaviour
{
    public GameObject textoPonto;
    public float tempoRespawn = 3f;
    private Animator alvoAnim;

    private void Start()
    {
        alvoAnim = GetComponent<Animator>();
    }

    public void Atingido()
    {
        GameObject ponto = Instantiate(textoPonto, transform.position, Quaternion.identity);
        ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.HitAlvo01);
        Ocultar();
        StartCoroutine(Respawn());
    }

    private void Ocultar()
    {
        alvoAnim.Play("Encolhendo");
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(tempoRespawn);

        alvoAnim.Play("Crescendo");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bola"))
        {
            GerenciadorFaseGeral.instancia.Pontuar();
            Atingido();
        }
    }
}
