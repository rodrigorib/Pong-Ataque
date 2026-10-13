using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bola"))
        {
            ControleSFX.instancia.PlayFX(ControleSFX.OpcaoSFX.Rebote);
        }
    }
}
