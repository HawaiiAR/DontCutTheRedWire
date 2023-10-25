using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

namespace BombParts
{
    public class BoomStickControl : BombComponent
    {

        protected override void Start()
        {
            //  grabable.enabled = false;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        public override void AddAttatcher(GameObject attatcher)
        {
            base.AddAttatcher(attatcher);
        }

        public override void RemoveAttatcher(GameObject attatcher)
        {
            if (attatcher != null)
            {
                base.RemoveAttatcher(attatcher);
            }
        }
    }
}
