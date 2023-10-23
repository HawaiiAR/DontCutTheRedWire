using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandTools
{
    public class ScissorControl : MonoBehaviour
    {
        [SerializeField] private GameObject[] _scissors;
        [SerializeField] private Collider[] _scissorColliders;

        bool canCut;
        // Start is called before the first frame update
        void Start()
        {
            ActivateCutColliders(false);
            canCut = false;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 closedPosition = _scissors[0].transform.forward - _scissors[1].transform.forward;
            float scissorAngle = Vector3.Angle(closedPosition, _scissors[1].transform.forward);

          //  Debug.Log("angle" + scissorAngle);
            if ((scissorAngle < 95f) && canCut == false)
            {
                
                ActivateCutColliders(true);
               Debug.Log("closed");
                canCut = true;
            }
            if ((scissorAngle > 100f) && canCut == true)
            {
                 Debug.Log("open");
                 ActivateCutColliders(false);
                canCut = false;
            }
        }


        private void ActivateCutColliders(bool state)
        {
          //  Debug.Log("activateColiders");
            foreach (Collider c in _scissorColliders)
            {
                c.enabled = state;
            }
        }
    }
}
