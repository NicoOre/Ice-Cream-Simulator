using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjetos : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = Vector3.zero;
        collision.transform.position = new Vector3(-0.6f, 1.1f, -0.3f);
    }
}
