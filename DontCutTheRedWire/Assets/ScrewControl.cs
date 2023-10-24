using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandTools
{
    public class ScrewControl : DrillbitControl
    {
    
    

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            spinTime = 3;
        }

        // Update is called once per frame
        void Update()
        {
            if (canSpin)
            {
                if (spinTime > 0)
                {
                    spinTime -= Time.deltaTime;
                    Spin();      
                }
                if(spinTime <= 0)
                {
                    ReleaseScrew();
                }
            }
        }



        protected override void ReleaseScrew()
        {
            _rb.isKinematic = false;
            _rb.useGravity = true;
            canSpin = false;
        }

      /*  private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Drill"))
            {
                canSpin = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Drill"))
            {
                canSpin = false;
            }
        }*/


    }
}
