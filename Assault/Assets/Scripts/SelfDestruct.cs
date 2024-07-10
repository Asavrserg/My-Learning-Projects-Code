using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeToDie;

    private void Start()
    {
        Destroy(this.gameObject, timeToDie);
    }
}
