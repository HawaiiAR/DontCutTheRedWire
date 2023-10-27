using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameControl;

namespace BombParts {
    public class BombExplosion : MonoBehaviour
    {
        [SerializeField] private GameObject _bombBroken;
        [SerializeField] private GameObject _bomb;
        [SerializeField] private float _blastRadius;
        [SerializeField] private float _blastForce;
        private Vector3 _epicenter;


        private void Awake()
        {
            _bombBroken.SetActive(false);
        }

        void Start()
        {
            _epicenter = this.transform.position;
            ArmedOrSafe.BombsGoneOff += Kaboom;
            TimerScript.Kaboom += Kaboom;
            BlastingWireBroken.WireBroken += Kaboom;
        }

        private void OnDisable()
        {
            ArmedOrSafe.BombsGoneOff -= Kaboom;
            TimerScript.Kaboom -= Kaboom;
            BlastingWireBroken.WireBroken += Kaboom;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hammer"))
            {
                Kaboom();
            }
        }

        private void Kaboom()
        {
            _bomb.SetActive(false);
            _bombBroken.SetActive(true);

            Collider[] _parts = Physics.OverlapSphere(_epicenter, _blastRadius);
            foreach (var part in _parts)
            {

                Rigidbody _rb = part.GetComponent<Rigidbody>();
                part.transform.parent = null;
                if (_rb == null)
                {
                    Rigidbody r = part.gameObject.AddComponent<Rigidbody>();
                    r.AddExplosionForce(_blastForce, _epicenter, _blastRadius, 10);
                }
                else
                {
                    _rb.isKinematic = false;
                    _rb.useGravity = true;
                    _rb.AddExplosionForce(_blastForce, _epicenter, _blastRadius, 10);
                }
            }
        }
    }
 
}
