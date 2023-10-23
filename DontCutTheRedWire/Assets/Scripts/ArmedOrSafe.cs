using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BombParts
{
    public class ArmedOrSafe : MonoBehaviour
    {

        public bool isArmed;
        // Start is called before the first frame update
        private void Start()
        {
            isArmed = true;
            ;
        }

        private void WireCut(string aliveOrDead)
        {
            switch (aliveOrDead)
            {
                case "alive":
                    Debug.Log("alive");
                    break;
                case "dead":
                    Debug.Log("dead");
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

                    WireCut("alive");
                }
            }
        }


    }
}
