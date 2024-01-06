using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BombParts;
using System;

namespace GameControl
{
    public class GameController : MonoBehaviour
    {
        public static Action<string> DifficultyLevel;
        public static Action GameStarted;

        [SerializeField] private GameObject _instructions;
        [SerializeField] private GameObject _win;
        [SerializeField] private GameObject _lose;
  
        [SerializeField] private List<GameObject> _parts = new List<GameObject>();
        private string _difficultyLevel;

        bool gameStarted;

        private void Awake()
        {
            TextArray("start");
        }

        void Start()
        {
            TimerScript.Kaboom += GameOver;
            ArmedOrSafe.BombsGoneOff += GameOver;
           
        }

        private void OnDisable()
        {
            TimerScript.Kaboom -= GameOver;
            ArmedOrSafe.BombsGoneOff -= GameOver;
        }

        public void Difficulty(string _dificulty)
        {
            _difficultyLevel = _dificulty;

            switch (_dificulty)
            {
                case "easy":
                    DifficultyLevel?.Invoke(_dificulty);

                    break;
                case "hard":
                    DifficultyLevel?.Invoke(_dificulty);

                    break;
                case "impossible":
                    DifficultyLevel?.Invoke(_dificulty);
                    break;
            }
        }


            void Update()
        {
            if (gameStarted)
            {
                if (_parts.Count <= 3)
                {
                    TextArray("win");
                }
            }

            if (Input.GetKeyDown("n"))
            {
                StartGame();
            }
        }

        public void StartGame()
        {
            GameStarted?.Invoke();
        }

        private void GameOver(){
            TextArray("lose");
        }

        private void TextArray(string textArrayState)
        {
            switch (textArrayState)
            {
                case "start":
                    TextAssets(true, false, false);
                    break;
                case "win":
                    TextAssets(false, true, false);
                    break;
                case "lose":
                    TextAssets(false, false, true);
                    break;
            }
        }

        private void TextAssets(bool instructionsState, bool winState, bool loseState)
        {
            _instructions.SetActive(instructionsState);
            _win.SetActive(winState);
            _lose.SetActive(loseState);
        }

        public void AddPartToList(GameObject part)
        {
            _parts.Add(part);
        }

        public void RemovePartFromList(GameObject part)
        {
            _parts.Remove(part);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
