using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HandTools
{
    public class BoltControl : MonoBehaviour
    {
      
        [SerializeField] private GameObject _bolt;
        [SerializeField] private float _moveSpeed;
        

        private GameObject _wrenchContact;
        private Vector3 _currentRotation;
        private Vector3 _startPos;
     Rigidbody _rb;
        bool canTurn;
        


        // Start is called before the first frame update
        void Start()
        {
            _startPos = this.transform.position;
            _rb = this.GetComponent<Rigidbody>();
            
       }

        // Update is called once per frame
        void Update()
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
                        if (_distance > .05f)
                        {
                            Debug.Log("bolt out");
                            _rb.isKinematic = false;
                            _rb.useGravity = true;
                        }
                    }
                 
                }
                
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wrench"))
            {
                Debug.Log("wrench");
                _currentRotation = _bolt.transform.up;
                _wrenchContact = other.gameObject;
                canTurn = true;
               


            }
        }


        private void OnTriggerExit(Collider other)
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
