using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Здоровье вражеского миньона!")]
    [SerializeField] int hitPoints = 3;

    [Tooltip("Инкремент здоровья вражеского миньона после его гибели!")]
    [SerializeField] int difficultyRamp = 1;
    
    private int currentHitPoint = 0;
    private Enemy enemy;


    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        currentHitPoint = Random.Range(hitPoints - 2, hitPoints + 2);
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;

        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            hitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
