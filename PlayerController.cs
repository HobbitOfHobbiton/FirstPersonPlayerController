using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : ControllerCore
    {
        [SerializeField] private Movement _movement;
        [SerializeField] public CameraRig _cameraRig;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private Bob _bob;
        [SerializeField] private Footsteps _footsteps;

        private CharacterController _characterController;
        private PlayerManager _playerManager;

        public bool _running;

        public CharacterController CharacterController
        {
            get { return _characterController; }
        }

        protected override void Start()
        {
            base.Start();

            GetReferences();

            _movement.Initialize(this, transform);
            _cameraController.Initialize(this, transform);
            _bob.Initialize(this, transform);
            _footsteps.Initialize(this, transform);
        }

        void GetReferences()
        {
            _characterController = GetComponent<CharacterController>();
            _playerManager = GetComponentInParent<PlayerManager>();
        }

        protected override void Update()
        {
            base.Update();

            if (!_playerManager.IsPaused)
            {
                _movement.UpdateMovement();
                _cameraController.UpdateCameraController();
                _bob.DoBob();
                _footsteps.UpdateFootsteps(_bob.BobCycle);
            }
        }

        private void FixedUpdate()
        {
            if (!_playerManager.IsPaused)
            {
                _movement.UpdateMovementPhysics();
            }
        }

        public void AddJumpForce(float _jumpPower)
        {
            _movement.Jump(_jumpPower);
        }

        public float CheapVelocityMagnitude()
        {
            float magnitude = Mathf.Abs(_characterController.velocity.x) + Mathf.Abs(_characterController.velocity.y) + Mathf.Abs(_characterController.velocity.z);
            magnitude /= 3;

            return magnitude;
        }
    }
}
