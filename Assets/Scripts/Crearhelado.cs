using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Crearhelado : MonoBehaviour
{

    public bool bandera;
    private Material clonedMaterial;
    public float r;
    public float g;
    public float b;
    public int heladoNumero;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        clonedMaterial = new Material(renderer.material);
        clonedMaterial.color = new Color(r,g,b);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "cuchara")
        {
            bandera = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        bandera = false; 
    }
}
