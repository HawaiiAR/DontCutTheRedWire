using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using BombParts;
using Oculus.Interaction;

namespace HandTools
{
    public class BoltControl : MonoBehaviour
    {
        [SerializeField] protected Grabbable grabable;
        [SerializeField] BombComponent bombComponent;
        [SerializeField] protected GameObject _bolt;
        [SerializeField] protected float _moveSpeed;


        protected GameObject _wrenchContact;
        protected Vector3 _currentRotation;
        protected Vector3 _startPos;

        protected Rigidbody _rb;

        protected bool canTurn;
        

        protected virtual void Start()
        {
            _startPos = this.transform.position;
            _rb = this.GetComponent<Rigidbody>();
            bombComponent.AddAttatcher(this.gameObject);
            grabable.enabled = false;

        }


        protected virtual void Update()
        {
            
            if (canTurn)
            {
                float contactAngle = Vector3.Angle(this.transform.forward, _wrenchContact.transform.forward);

                if (contactAngle < 10)
                {
                   
                    _bolt.transform.rotation = _wrenchContact.transform.rotation *
                         Quaternion.FromToRotation(_wrenchContact.transform.forward, this.transform.forward);

                    float boltRotAngle = Vector3.Angle(_currentRotation, _bolt.transform.up);
                 
                    if (boltRotAngle > 10)
                    {
                       
                       this.transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
                        float _distance = Vector3.Distance(this.transform.position, _startPos);
                        if (_distance > .01f)
                        {
                            ReleaseBolt();
                        }
                    }
                 
                }
                
            }
        }


        protected virtual void ReleaseBolt()
        {
            grabable.enabled = true;
            grabable.gameObject.transform.parent = null;
            Debug.Log("bolt out");
            bombComponent.RemoveAttatcher(this.gameObject);
          //  _rb.isKinematic = false;
         //  _rb.useGravity = true;
           
        }


        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wrench"))
            {
                Debug.Log("wrench");
                _currentRotation = _bolt.transform.up;
                _wrenchContact = other.gameObject;
                canTurn = true;

            }
        }


        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Wrench"))
            {

                _wrenchContact = other.gameObject;
                canTurn = false;

            }
        }

       /* private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wrench"))
            {
                Debug.Log("hit wrench");
                _wrenchContact = collision.gameObject;
                canTurn = true;
            }
        }


        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wrench"))
            {
                Debug.Log("hit wrench");
                _wrenchContact = collision.gameObject;
                canTurn = false;
            }
        }*/
    }
}
