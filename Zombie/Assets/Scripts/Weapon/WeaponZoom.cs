using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class WeaponZoom : MonoBehaviour
    {
        [SerializeField] Camera fpsCamera;
        [SerializeField] RigidbodyFirstPersonController fpsController;

        [SerializeField] float zoomedOutFov = 60f;
        [SerializeField] float zoomedInFov = 30f;

        [SerializeField] float zoomOutSens = 2f;
        [SerializeField] float zoomInSens = 1f;

        private bool zoomedInToggle = false;

        private void OnDisable()
        {
            ZoomOut();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!zoomedInToggle)
                {
                    ZoomIn();
                }
                else
                {
                    ZoomOut();
                }
            }
        }
        
        private void ZoomIn()
        {
            zoomedInToggle = true;
            fpsCamera.fieldOfView = zoomedInFov;

            fpsController.mouseLook.XSensitivity = zoomInSens;
            fpsController.mouseLook.YSensitivity = zoomInSens;
        }

        private void ZoomOut()
        {
            zoomedInToggle = false;
            fpsCamera.fieldOfView = zoomedOutFov;

            fpsController.mouseLook.XSensitivity = zoomOutSens;
            fpsController.mouseLook.YSensitivity = zoomOutSens;
        }
    }
}

