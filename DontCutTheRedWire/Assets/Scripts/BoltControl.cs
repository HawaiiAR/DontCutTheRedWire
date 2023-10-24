using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandTools
{
    public class BoltControl : MonoBehaviour
    {
      
        [SerializeField] private GameObject _bolt;
        [SerializeField] private float _moveSpeed;
        

        private GameObject _wrenchContact;
        private Vector3 _currentRotation;
       
        [SerializeField] Rigidbody _rb;
        bool canTurn;
        


        // Start is called before the first frame update
        void Start()
        {
            
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
                    }
                 
                }
                
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wrench"))
            {
                _currentRotation = _bolt.transform.up;
                _wrenchContact = other.gameObject;
                _rb = other.GetComponent<Rigidbody>();
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
