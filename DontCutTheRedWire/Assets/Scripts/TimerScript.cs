using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BombParts;

namespace GameControl
{
    public class TimerScript : MonoBehaviour
    {

        public static Action Kaboom;
        public bool stopTimer;

        [SerializeField] BombComponent _timeBody;
        [SerializeField] private float _minutes;
        [SerializeField] private float _seconds;
        [SerializeField] private float _gameTime;

        [SerializeField] private TMP_Text _timeDisplay;
        

        bool gameStarted = false;


        void Start()
        {
            // subscribe to game start to set timer for now start on enable
            _timeDisplay.text = _gameTime.ToString();
            stopTimer = false;

        }

        private void OnEnable()
        {
            StartGame();
        }


        void Update()
        {
            if (gameStarted && stopTimer == false)
            {
                
                GameTimer();
                if (_seconds <= 0)
                {
                    Kaboom?.Invoke();
                    gameStarted = false;
                }

                if(_timeBody._attatchers.Count <= 0)
                {
                    stopTimer = true;
                }
            }
           

        }

        private void StartGame()
        {
           
            gameStarted = true;
          

        }

        public virtual void GameTimer()
        { 
            _gameTime -= Time.deltaTime;
            _minutes = Mathf.FloorToInt(_gameTime / 60);
            _seconds = Mathf.FloorToInt(_gameTime % 60);
            _timeDisplay.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);

        }
    }
}
