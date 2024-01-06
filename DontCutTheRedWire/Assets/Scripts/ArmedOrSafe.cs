using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace BombParts
{
    public class ArmedOrSafe : MonoBehaviour
    {
        public static Action BombsGoneOff;

        [SerializeField] BombComponent bombComponent;
        public bool isArmed = false;

        private MeshRenderer _rend;
        private List<Color> _wireColors = new List<Color> { Color.black, Color.blue, Color.green, Color.cyan, Color.magenta };

        private void Awake()
        {
            _rend = this.GetComponent<MeshRenderer>();
        }


        private void WireCut(string aliveOrDead)
        {
            switch (aliveOrDead)
            {
                case "alive":
                    Debug.Log("alive");
                    break;
                case "dead":
                    BombsGoneOff?.Invoke();
                    break;
            }
            Destroy(this.gameObject);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Scissors"))
            {
                if (isArmed)
                {
                    
                    WireCut("dead");
                }
                if (!isArmed)
                {
                    bombComponent.RemoveAttatcher(this.gameObject);
                    WireCut("alive");
                }
            }
        }

        public void SetColor()
        {
            if (isArmed)
            {
                _rend.material.color = Color.red;
            }
            else
            {
                int randColor = UnityEngine.Random.Range(0, _wireColors.Count);
                _rend.material.color = _wireColors[randColor];
                bombComponent.AddAttatcher(this.gameObject);
            }
           
        }


    }
}
