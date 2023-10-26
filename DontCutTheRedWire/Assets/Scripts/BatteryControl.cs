using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using GameControl;

namespace BombParts
{
    public class BatteryControl : BombComponent
    {
        
        protected override void Start()
        {
            GameController.GameStarted += StartGame;
          
            isAttatched = true;
            if (grabable != null)
            {
                grabable.enabled = false;
            }

            gameControl = FindObjectOfType<GameController>();
            gameControl.AddPartToList(this.gameObject);

        }
     


        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

           /* if (gameStarted)
            {
                if (_attatchers.Count <= 0 && isAttatched)
                {
                    Debug.Log("free");
                   
                        grabable.enabled = true;
                    
                    gameControl.RemovePartFromList(this.gameObject);
                    isAttatched = false;
                }
            }
            if (Input.GetKeyDown("g"))
            {
                grabable.enabled = true;
            }*/
        }

        public override void AddAttatcher(GameObject attatcher)
        {
            base.AddAttatcher(attatcher);
        }

        public override void RemoveAttatcher(GameObject attatcher)
        {
            if (attatcher != null)
            {
                base.RemoveAttatcher(attatcher);
            }
        }
    }
}
