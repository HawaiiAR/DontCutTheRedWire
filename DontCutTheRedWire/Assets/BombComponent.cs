using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombParts
{
    public class BombComponent : MonoBehaviour
    {

        [SerializeField] private GameObject[] _wires;
        [SerializeField] private GameObject[] _attatchers;

        [SerializeField] private List<GameObject> _activeWires;
        ArmedOrSafe armedOrSafe;

        // Start is called before the first frame update
        void Start()
        {
            SetWires();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetWires()
        {
            foreach (GameObject w in _wires)
            {
                w.SetActive(false);
            }
            int visibleWires = Random.Range(3, _wires.Length);

            Debug.Log("active wires" + visibleWires);

            for (int i = 0; i < visibleWires; i++)
            {
                int aWire = Random.Range(1, visibleWires);
              //  GameObject wire = _wires[aWire];

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
    }
}
