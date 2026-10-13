using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebatedorAtual : MonoBehaviour
{
    public Rebate rebateEsquedo;
    public Rebate rebateDireito;

    public bool rebatidaEsquerda = true;

    private void Start()
    {
        rebateEsquedo.RebateuBolinha += () => rebatidaEsquerda = true;
        rebateDireito.RebateuBolinha += () => rebatidaEsquerda = false;
    }
}
