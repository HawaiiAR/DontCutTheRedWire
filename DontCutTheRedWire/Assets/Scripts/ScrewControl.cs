using System.Collections;
using System.Collections.Generic;
using BombParts;
using UnityEngine;

namespace HandTools
{
    public class ScrewControl : DrillbitControl
    {
        [SerializeField] BombComponent bombComponent;


        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            spinTime = 3;
            bombComponent.AddAttatcher(this.gameObject);
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
            bombComponent.RemoveAttatcher(this.gameObject);
            this.transform.parent = null;
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
