using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandTools{

public class DrillbitControl : MonoBehaviour
{
    [SerializeField] protected float spinTime;
    [SerializeField] protected float rotSpeed;
    [SerializeField] protected float moveSpeed;
    private Vector3 _startPos;

    protected Rigidbody _rb;
    protected bool canSpin;


        // Start is called before the first frame update
       protected virtual void Start()
    {
            _rb = this.GetComponent<Rigidbody>();
            _startPos = this.transform.localPosition;
        }

    // Update is called once per frame
    void Update()
    {
            if (canSpin)
            {           
                    Spin();
            }
        }

        protected virtual void ReleaseScrew()
        {
      
            canSpin = false;
        }

        protected virtual void Spin()
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<ScrewControl>(out ScrewControl screw)) return;

            else
            {
             
                canSpin = true;
                screw.rotSpeed = rotSpeed * -1;
                screw.moveSpeed = moveSpeed * -1;
                screw.canSpin = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<ScrewControl>(out ScrewControl screw)) return;

            else
            {
                this.transform.localPosition = _startPos;
                canSpin = false;
                screw.canSpin = false;
            }
        }
    }
}
