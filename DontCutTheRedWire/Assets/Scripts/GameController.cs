using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameControl
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _parts = new List<GameObject>();


        bool gameStarted;


        void Start()
        {
            TimerScript.Kaboom += GameOver;
        }

        private void OnDisable()
        {
            TimerScript.Kaboom -= GameOver;
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
