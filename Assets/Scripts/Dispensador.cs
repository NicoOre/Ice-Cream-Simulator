using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Dispensador : MonoBehaviour
{
    public GameObject objeto;
    public Vector3 posicion;
    public Quaternion rot;

    public void aparecer()
    {
        Instantiate(objeto, posicion, rot);
    }

}
