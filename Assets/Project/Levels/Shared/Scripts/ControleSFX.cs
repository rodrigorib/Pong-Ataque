using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSFX : MonoBehaviour
{
    public static ControleSFX instancia;
    public enum OpcaoSFX
    {
        BolaPerdida,
        Botao,
        Derrota,
        HitAlvo01,
        HitAlvo02,
        HitAlvo03,
        PosseBola,
        Rebatida,
        Rebote,
        Vitoria
    }

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip bolaPerdidaSFX;
    [SerializeField]
    private AudioClip rebatidaSFX;
    [SerializeField]
    private AudioClip posseBolaSFX;
    [SerializeField]
    private AudioClip reboteSFX;
    [SerializeField]
    private AudioClip botaoSFX;
    [SerializeField]
    private AudioClip vitoriaSFX;
    [SerializeField]
    private AudioClip derrotaSFX;
    [SerializeField]
    private AudioClip hitAlvo01SFX;
    [SerializeField]
    private AudioClip hitAlvo02SFX;
    [SerializeField]
    private AudioClip hitAlvo03SFX;

    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFX(OpcaoSFX opcaoSFX)
    {
        switch (opcaoSFX)
        {
            case OpcaoSFX.HitAlvo01:
                audioSource.PlayOneShot(hitAlvo01SFX);
                break;
            case OpcaoSFX.HitAlvo02:
                audioSource.PlayOneShot(hitAlvo02SFX);
                break;
            case OpcaoSFX.HitAlvo03:
                audioSource.PlayOneShot(hitAlvo03SFX);
                break;
            case OpcaoSFX.Rebatida:
                audioSource.PlayOneShot(rebatidaSFX);
                break;
            case OpcaoSFX.BolaPerdida:
                audioSource.PlayOneShot(bolaPerdidaSFX);
                break;
            case OpcaoSFX.PosseBola:
                audioSource.PlayOneShot(posseBolaSFX);
                break;
            case OpcaoSFX.Rebote:
                audioSource.PlayOneShot(reboteSFX);
                break;
            case OpcaoSFX.Derrota:
                audioSource.PlayOneShot(derrotaSFX);
                break;
            case OpcaoSFX.Vitoria:
                audioSource.PlayOneShot(vitoriaSFX);
                break;
            case OpcaoSFX.Botao:
                audioSource.PlayOneShot(botaoSFX);
                break;
            default:
                break;
        }
    }
}
