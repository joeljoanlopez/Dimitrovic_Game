using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraTarget_Changer : MonoBehaviour
    {
        public CameraController cameraController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                cameraController.SetTarget(transform);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                cameraController.SetTarget(other.transform);
            }
        }
    }
}