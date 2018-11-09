using Assets.Scripts.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{

    public class Test : MonoBehaviour
    {

        public FrameCooldown cooldown;

        // Use this for initialization
        void Start()
        {
            cooldown = new FrameCooldown(60, 10, 1);
        }

        // Update is called once per frame
        void Update()
        {
            cooldown.Update();
            if (cooldown.isReady())
            {
                return;
            }

            Debug.Log(cooldown.value);
        }

        private void FixedUpdate()
        {

        }
    }
}
