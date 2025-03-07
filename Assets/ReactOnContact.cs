using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactOnContact : MonoBehaviour
{
    [SerializeField] private Rigidbody rigBody;
    void OnTriggerEnter(Collider other)
{
    
    if (other.CompareTag(rigBody.tag))
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
}

}
