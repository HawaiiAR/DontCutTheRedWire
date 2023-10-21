using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HandTools
{
    public class ToolControl : MonoBehaviour
    {

        [SerializeField] private GameObject[] _scissors;
        [SerializeField] private GameObject _drill;
        [SerializeField] private GameObject _hand;
        [SerializeField] private GameObject _hammer;
        [SerializeField] private GameObject _wrench;


        // Start is called before the first frame update
        void Start()
        {
            ActivateTool(false, false, false, false, true);
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void TooSelector(string tool)
        {
            switch (tool)
            {
                case "scissors":
                    ActivateTool(true, false, false, false, false);
                    Debug.Log("Scissors");
                    break;
                case "drill":
                    ActivateTool(false, true, false, false, false);
                    break;
                case "hammer":
                    ActivateTool(false, false, true, false, false);
                    break;
                case "wrench":
                    ActivateTool(false, false, false, true, false);
                    break;
                case "hand":
                    ActivateTool(false, false, false, false, true);
                    break;
            }
        }
    
   
      private void ActivateTool(bool scissors, bool drill, bool hammer, bool wrench, bool hand)
        {
            ActivateScissors(scissors);
            _drill.SetActive(drill);
            _hammer.SetActive(hammer);
            _wrench.SetActive(wrench);
            _hand.SetActive(hand);
        }
        private void ActivateScissors(bool activated)
        {
            Debug.Log("Deacivate Scisors");
            foreach(var s in _scissors)
            {
                s.SetActive(activated);
            }
        }



    }
}
