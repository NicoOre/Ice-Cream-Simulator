using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirHelado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -0.5f)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Entregable")
        {
            Debug.Log("fsdfsdfdsdddfsfsdf");
            gameObject.transform.position = other.transform.GetChild(1).transform.position;
            gameObject.transform.parent = other.transform.GetChild(1).transform;
        }
    }
}
