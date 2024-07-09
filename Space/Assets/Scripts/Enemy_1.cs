using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Settings")]
    public float waveFrequency = 2f; 
    public float waveWidth = 4f;
    public float waveRotY = 45f;

    private float x0;
    private float birthTime;

    void Start()
    {
        x0 = pos.x;

        birthTime = Time.time;
    }

    // переопределить функцию Move суперкласса Enemy
    public override void Move()
    {
        // так как pos - свойство, нельзя напрямую изменить pos.x
        // поэтому получим pos в виде вектора Vector3, доступного для изменения
        Vector3 tempPos = pos;

        // значение theta изменяется с течением времени
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        // base.Move() обрабатывает движение вниз, вдоль оси Y
        base.Move();
    }
}
