using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameControl;
using System;
using Oculus.Interaction;

namespace HandTools
{

    public class BlastingCap : BoltControl
    {
    
        GameController gameControl;
       

        bool isActive;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            gameControl = FindObjectOfType<GameController>();
            gameControl.AddPartToList(this.gameObject);
        

        }
        protected override void Update()
        {
            base.Update();
            
        }
        protected override void ReleaseBolt()
        {
            base.ReleaseBolt();
   
            gameControl.RemovePartFromList(this.gameObject);

         
        }
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
        }

   
    }
}
