using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;

public class BolaDeHelado : MonoBehaviour
{

    public GameObject bolaDeHelado;
    public GameObject anchorCuchara;
    public List<Crearhelado> helados;
    public Material colorHelado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void agarrarHelado()
    {
        for (int i = 0; i < helados.Count; i++)
        {
            if (helados[i].bandera && anchorCuchara.transform.childCount == 0)
            {
                colorHelado.color = new Color(helados[i].r, helados[i].g, helados[i].b);
                bolaDeHelado.GetComponent<saborHelado>().numeroSabor = helados[i].heladoNumero;
                Instantiate(bolaDeHelado, anchorCuchara.transform.position, anchorCuchara.transform.rotation, anchorCuchara.transform);
                break;
            }
        }  
    }

    public void soltarHelado()
    {
        if (anchorCuchara.transform.childCount == 1)
        {
            anchorCuchara.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            anchorCuchara.transform.GetChild(0).parent = null;
        }
    }
}
