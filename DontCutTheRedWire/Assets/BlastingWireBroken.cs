using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BombParts
{
    public class BlastingWireBroken : MonoBehaviour
    {
        public static Action WireBroken;
        [SerializeField] private HingeJoint _joint;

        // Start is called before the first frame update
        void Start()
        {
            _joint = this.GetComponent<HingeJoint>();
        }

        private void OnJointBreak(float breakForce)
        {
            Debug.Log("wire broken");
            WireBroken?.Invoke();
        }
    }
}
