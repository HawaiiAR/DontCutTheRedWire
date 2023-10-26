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
        public static Action GameStarted;

        [SerializeField] private List<GameObject> _parts = new List<GameObject>();


        bool gameStarted;


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


        void Update()
        {
            if (gameStarted)
            {
                if (_parts.Count <= 3)
                {
                    Debug.Log("PlayerWins");
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

        private void GameOver()
        {

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
