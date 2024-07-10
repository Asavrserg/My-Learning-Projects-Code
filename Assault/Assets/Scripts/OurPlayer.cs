using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OurPlayer : MonoBehaviour
{
    [Header("Inputs for InputSystem!")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;


    [Header("General Setup Settings!")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 30f;

    [Tooltip("How far player moves horizontally")]
    [SerializeField] float xRange = 1.6f;

    [Tooltip("How far player moves vertically")]
    [SerializeField] float yRange = 1.2f;


    [Header("Screen Position Based Tuning!")]
    [SerializeField] float posPitchFactor = -2f;
    [SerializeField] float posYawFactor = 2f;

    [Header("Player Input Based Tuning!")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -25f;


    [Header("Laser Gun Array!")]
    [Tooltip("Add All Player Lasers Here")]
    [SerializeField] GameObject[] lasers;

    float horThrow, verThrow;


    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }


    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation()
    {
        horThrow = movement.ReadValue<Vector2>().x;
        verThrow = movement.ReadValue<Vector2>().y;

        float xOffset = horThrow * controlSpeed * Time.deltaTime;
        float rawPosX = transform.localPosition.x + xOffset;
        float clampedPosX = Mathf.Clamp(rawPosX, -xRange, xRange);

        float yOffset = verThrow * controlSpeed * Time.deltaTime;
        float rawPosY = transform.localPosition.y + yOffset;
        float clampedPosY = Mathf.Clamp(rawPosY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedPosX, clampedPosY, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPos = transform.localPosition.y * posPitchFactor;
        float pitchDueToControlThrow = verThrow * controlPitchFactor;

        float pitch = pitchDueToPos + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * posYawFactor;
        float roll = horThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    private void ProcessFiring()
    {
        if (fire.ReadValue<float>() > 0.5f)
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
