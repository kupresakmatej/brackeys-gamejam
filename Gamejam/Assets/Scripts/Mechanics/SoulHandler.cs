using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHandler : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
