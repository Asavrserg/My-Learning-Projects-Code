using System.Collections;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] [Range(10f, 100f)] float range;
    [SerializeField] [Range(5f, 100f)] float damage;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    [SerializeField] ParticleSystem muzzleEffect;
    [SerializeField] GameObject hitEffect;
    [SerializeField] [Range(0.1f, 2f)] float timeBetweenShots = 0.5f;

    [SerializeField] TextMeshProUGUI ammoText;

    private RaycastHit hit;
    private EnemyHealth enemyHealth;

    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmoAmmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.GetCurrentAmmoAmmount(ammoType) > 0)
        {
            PlayMuzzleEffect();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }

    private void PlayMuzzleEffect()
    {
        muzzleEffect.Play();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth == null) return;
            
            enemyHealth.TakeDamage(damage);
        }
        else return;       
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
