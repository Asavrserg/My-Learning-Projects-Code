using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] [Range(10f, 50f)] float damage;

    private PlayerHealth playerHealth;
    private DisplayDamage displayDamage;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        displayDamage = FindObjectOfType<DisplayDamage>();
    }

    public void AttackHitEvent()
    {
        if (playerHealth == null) return;

        playerHealth.TakeDamage(damage);
        displayDamage.ShowDamageImpact();
    }
}
