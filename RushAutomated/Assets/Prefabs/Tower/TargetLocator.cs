using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform myUpWeapon;
    [SerializeField] ParticleSystem myProjectiles;
    [SerializeField] float range = 15f;

    private Transform target;


    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void AimWeapon()
    {
        myUpWeapon.LookAt(target);

        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = myProjectiles.emission;
        emissionModule.enabled = isActive;
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }
}
