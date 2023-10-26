using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Oculus.Interaction;
using GameControl;

namespace BombParts
{
    public class BombComponent : MonoBehaviour
    {
       
        protected  ArmedOrSafe armedOrSafe;
        protected GameController gameControl;

        [SerializeField] protected Grabbable grabable;
        [SerializeField] protected GameObject[] _wires;
        [SerializeField] public List<GameObject> _attatchers = new List<GameObject>();
        [SerializeField] protected List<GameObject> _activeWires;

        protected bool gameStarted;
        protected bool isAttatched;

        protected virtual void Start()
        {
            GameController.GameStarted += StartGame;
            isAttatched = true;

            SetWires();
            gameControl = FindObjectOfType<GameController>();
           

            gameControl.AddPartToList(this.gameObject);
            if (grabable != null)
            {
                grabable.enabled = false;
            }
        }

        protected virtual void OnDisable()
        {
            GameController.GameStarted -= StartGame;
        }

        protected virtual void StartGame()
        {
            gameStarted = true;
        }
        

        protected virtual void Update()
        {
            if (gameStarted)
            {
                if(_attatchers.Count <= 0 && isAttatched)
                {
                    if (grabable != null)
                    {
                        grabable.enabled = true;
                    }
                    gameControl.RemovePartFromList(this.gameObject);
                    isAttatched = false;
                }
            }
        }

        protected virtual void SetWires()
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

        protected virtual void ActivateWires()
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

        public virtual void AddAttatcher(GameObject attatcher)
        {
            _attatchers.Add(attatcher);
        }

        public virtual void RemoveAttatcher(GameObject attatcher)
        {
            if (attatcher != null)
            {
                _attatchers.Remove(attatcher);
            }
        }
    }
}
