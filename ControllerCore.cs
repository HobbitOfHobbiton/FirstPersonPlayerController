﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public abstract class ControllerCore : MonoBehaviour
    {
        //---------------( ͡° ͜ʖ ͡°)--------------
        public float Horizontal
        {
            get { return Input.GetAxis("Horizontal"); }
        }

        public float Vertical
        {
            get { return Input.GetAxis("Vertical"); }
        }

        public float MouseX
        {
            get { return Input.GetAxis("Mouse X"); }
        }

        public float MouseY
        {
            get { return Input.GetAxis("Mouse Y"); }
        }

        public bool Sprint
        {
            get { return Input.GetButton("Sprint"); }
        }

        public bool Jump
        {
            get { return Input.GetButtonDown("Jump"); }
        }

        //---------( ͡° ͜ʖ ͡°)( ͡° ͜ʖ ͡°)----------------
        protected virtual void Start ()
        {

        }

        protected  virtual void Update ()
        {
            
        }
    }
}
