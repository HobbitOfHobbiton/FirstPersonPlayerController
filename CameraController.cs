using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    [System.Serializable]
    public class CameraController : PlayerControllerUtilities
    {
        [SerializeField] private float _sensitivity = 5.0f;
        [SerializeField] private float _smoothing = 0.1f;
        [SerializeField] private float _minPich = -90;
        [SerializeField] private float _maxPitch = 90;

        private float _pitchV, _yawV;
        private float _pitch, _yaw;
        private float _currentPitch, _currentYaw;
        
        public void UpdateCameraController ()
        {
            if (_pc._cameraRig.IsValid())
            {
                ModifyInput();
                SmoothenAngles();
                ApplyAngles();
            }
        }

        void ModifyInput()
        {
            _pitch -= _pc.MouseY * _sensitivity;
            _yaw += _pc.MouseX * _sensitivity;

            _pitch = Mathf.Clamp( _pitch, _minPich, _maxPitch);
        }

        void SmoothenAngles()
        {
            _currentPitch = Mathf.SmoothDamp(_currentPitch, _pitch, ref _pitchV, _smoothing);
            _currentYaw = Mathf.SmoothDamp(_currentYaw, _yaw, ref _yawV, _smoothing);
        }

        void ApplyAngles()
        {
            _pc._cameraRig.CameraPivot.localRotation = Quaternion.Euler(_currentPitch, 0, 0);
            _transform.localRotation = Quaternion.Euler(0, _currentYaw, 0);
        }

    }
}
