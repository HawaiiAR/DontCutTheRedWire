using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

namespace GameControl {
    public class TimerScript : MonoBehaviour
    {

        public static Action Kaboom;
        
        [SerializeField] private float _minutes;
        [SerializeField] private float _seconds;
        [SerializeField] private float _gameTime;

        [SerializeField] private TMP_Text _timeDisplay;

        bool gameStarted = false;


        void Start()
        {
            // subscribe to game start to set timer for now start on enable
            _timeDisplay.text = _gameTime.ToString();
        }

        private void OnEnable()
        {
            StartGame();
        }


        void Update()
        {
            if (gameStarted)
            {
                GameTimer();
                if (_seconds <= 0 )
                {
                    Kaboom?.Invoke();
                    gameStarted = false;
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
