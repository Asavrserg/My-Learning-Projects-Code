using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffects;
    [SerializeField] GameObject viewGameObject;

    private OurPlayer ourPlayer;
    private BoxCollider boxCollider;

    private void Start()
    {
        ourPlayer = this.GetComponent<OurPlayer>();
        boxCollider = this.GetComponent<BoxCollider>();
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
        StartCrashSequence();
    }


    private void StartCrashSequence()
    {
        crashEffects.Play();
        viewGameObject.SetActive(false);
        ourPlayer.enabled = false;
        boxCollider.enabled = false;
        
        Invoke("ReloadLevel", 1f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
