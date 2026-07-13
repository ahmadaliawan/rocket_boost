using UnityEngine;
#if UNITY_CINEMACHINE
using Unity.Cinemachine;
#endif

public class CameraMouseOrbit : MonoBehaviour
{
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    
    void Update()
    {
#if UNITY_CINEMACHINE
        var orbitalFollow = GetComponent<CinemachineOrbitalFollow>();
        if (orbitalFollow != null)
        {
            float mouseX = 0f;
            float mouseY = 0f;
            
            try 
            {
                mouseX = Input.GetAxis("Mouse X");
                mouseY = Input.GetAxis("Mouse Y");
            } 
            catch 
            {
                // Fallback if old input system is entirely disabled
            }

            var hAxis = orbitalFollow.HorizontalAxis;
            hAxis.Value += mouseX * sensitivityX;
            orbitalFollow.HorizontalAxis = hAxis;

            var vAxis = orbitalFollow.VerticalAxis;
            vAxis.Value -= mouseY * sensitivityY;
            orbitalFollow.VerticalAxis = vAxis;
        }
#endif
    }
}