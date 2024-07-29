using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 50f;
    [SerializeField] float addIntensity = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var flashlightScript = other.GetComponentInChildren<FlashLight>();

            flashlightScript.RestoreLightAngle(restoreAngle);
            flashlightScript.RestoreLightIntensity(addIntensity);

            Destroy(gameObject);
        }
    }
}
