using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 5f;
    MeshRenderer rendererDrop;
    Rigidbody rigidbodyDrop;

    void Start()
    {
        rendererDrop = GetComponent<MeshRenderer>();
        rendererDrop.enabled = false;

        rigidbodyDrop = GetComponent<Rigidbody>();
        rigidbodyDrop.useGravity = false;
    }

    void Update()
    {
        if (Time.time > timeToWait)
        {
            rendererDrop.enabled = true;
            rigidbodyDrop.useGravity = true;
        }
    }
}
