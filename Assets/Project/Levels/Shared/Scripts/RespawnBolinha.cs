using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBolinha : MonoBehaviour
{
    public GameObject bolinha;
    public event Action fimAnimacao;

    public void LancarBolinha()
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("Spawn");
    }

    public void Lancar()
    {
        fimAnimacao?.Invoke();
        Instantiate(bolinha, transform.position, Quaternion.identity);
    }
}
