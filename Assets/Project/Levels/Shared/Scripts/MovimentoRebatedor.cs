using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRebatedor : MonoBehaviour
{
    public GameObject rebatedorL;
    public GameObject rebatedorR;
    private Rigidbody2D rbL;
    private Rigidbody2D rbR;
    public float velocidade = 3f;
    public bool rebatendo = false;

    private float inputEixoYL;
    private float inputEixoYR;

    // Start is called before the first frame update
    void Start()
    {
        rbL = rebatedorL.GetComponent<Rigidbody2D>();
        rbR = rebatedorR.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputEixoYL = Input.GetAxisRaw("VerticalL");
        inputEixoYR = Input.GetAxisRaw("VerticalR");
    }

    private void FixedUpdate()
    {
        if (!rebatendo)
        {
            // Modifica apenas a velocidade vertical
            rbL.velocity = new Vector2(0f, inputEixoYL * velocidade);
            rbR.velocity = new Vector2(0f, inputEixoYR * velocidade);
        }
        else
        {
            rbL.velocity = Vector2.zero;
            rbR.velocity = Vector2.zero;
        }
    }
}
