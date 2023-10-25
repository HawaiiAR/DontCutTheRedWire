using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Oculus.Interaction;

namespace BombParts
{
    public class BombComponent : MonoBehaviour
    {
        Grabbable grabable;
        ArmedOrSafe armedOrSafe;

        [SerializeField] private GameObject[] _wires;
        [SerializeField] private List<GameObject> _attatchers = new List<GameObject>();
        [SerializeField] private List<GameObject> _activeWires;

        bool gameStarted;
        bool isAttatched;

        void Start()
        {
            SetWires();
            grabable.enabled = false;
        }

        private void Update()
        {
            if (gameStarted)
            {
                if(_attatchers.Count <= 0 && isAttatched)
                {
                    grabable.enabled = true;
                    isAttatched = false;
                }
            }
        }

        private void SetWires()
        {
            foreach (GameObject w in _wires)
            {
                w.SetActive(false);
            }
            int visibleWires = Random.Range(3, _wires.Length);

          //  Debug.Log("active wires" + visibleWires);

            for (int i = 0; i < visibleWires; i++)
            {
                int aWire = Random.Range(1, visibleWires);

                if (_wires[aWire] != null)
                {
                    _wires[aWire].SetActive(true);
                    _activeWires.Add(_wires[aWire]);
                   
                }
            }

            ActivateWires();
        }

        private void ActivateWires()
        {
            int randomWire = Random.Range(0, _activeWires.Count);
            _activeWires[randomWire].GetComponent<ArmedOrSafe>().isArmed = true;

            foreach (GameObject w in _activeWires)
            {
                if (w != null)
                {
                    armedOrSafe = w.GetComponent<ArmedOrSafe>();
                    armedOrSafe.SetColor();
                }
            }

        }

        public void AddAttatcher(GameObject attatcher)
        {
            _attatchers.Add(attatcher);
        }

        public void RemoveAttatcher(GameObject attatcher)
        {
            if (attatcher != null)
            {
                _attatchers.Remove(attatcher);
            }
        }
    }
}
