using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombParts
{
    public class ScrewControl : MonoBehaviour
    {
        [SerializeField] private float _spinTime;
        [SerializeField] private float _rotSpeed;
        [SerializeField] private float _moveSpeed;
        private Rigidbody _rb;

        bool canSpin;
        // Start is called before the first frame update
        void Start()
        {
            _rb = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (canSpin)
            {
                if (_spinTime > 0)
                {
                    _spinTime -= Time.deltaTime;
                    transform.Rotate(0, 0, _rotSpeed * Time.deltaTime);
                    transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
                }
                if(_spinTime <= 0)
                {
                    _rb.isKinematic = false;
                    _rb.useGravity = true;
                    canSpin = false;
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
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
        }


    }
}
