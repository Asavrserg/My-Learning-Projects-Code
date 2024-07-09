using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    [Header("Settings")]
    public float sinEccentricity = 0.6f;
    public float lifeTime = 10f;

    [Header("Dynamically")]
    public Vector3 p0;
    public Vector3 p1;
    public float birthTime;

    void Start()
    {
        p0 = Vector3.zero;
        p0.x = -bndCheck.camWidth - bndCheck.radius;
        p0.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        p1 = Vector3.zero;
        p1.x = bndCheck.camWidth + bndCheck.radius;
        p1.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        if (Random.value > 0.5f)
        {
            p0.x *= -1;
            p1.x *= -1;
        }

        birthTime = Time.time;
    }

    public override void Move()
    {
        // кривые Безье вычисляются на основе значения u между 0 и 1
        float u = (Time.time - birthTime) / lifeTime;

        // если u > 1, корабль существует дольше, чем lifeTime
        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        
            // скорректировать u добавлением значения кривой,
            // изменяющейся по синусоиде
            u = u + sinEccentricity * (Mathf.Sin(u * Mathf.PI * 2));

            // интерполировать местоположение между двумя точками
            pos = (1 - u) * p0 + u * p1;
    }
}
