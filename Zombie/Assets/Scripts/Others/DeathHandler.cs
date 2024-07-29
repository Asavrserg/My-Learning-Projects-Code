using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    private WeaponSwitcher weaponSwitcher;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
        weaponSwitcher.enabled = false;
    }
}
