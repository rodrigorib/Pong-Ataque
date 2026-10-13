using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            if (collision.enabled)
                ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.Rebote);
        }
    }
}
