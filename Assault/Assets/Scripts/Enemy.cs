using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject hitEffect;

    private GameObject parentGameObject;
    private ScoreBoard scoreBoard;
    private int randHitPoints;


    private void Start()
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        scoreBoard = FindObjectOfType<ScoreBoard>();
        randHitPoints = Random.Range(10, 25);
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (randHitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.transform.parent = parentGameObject.transform;

        randHitPoints--;
        scoreBoard.IncreaseScore(5);
    }

    private void KillEnemy()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        effect.transform.parent = parentGameObject.transform;

        Destroy(this.gameObject);
    }
}
