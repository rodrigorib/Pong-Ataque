using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TextoPonto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayDestruir());
    }

    private IEnumerator DelayDestruir()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
