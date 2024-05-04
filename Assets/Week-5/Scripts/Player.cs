using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeGame
{
    public class Player : MonoBehaviour
    {
        public void Start()
        {
            GameManager.AddGameOverEventListener(OnGameOver);
        }

        private void OnGameOver()
        {
            gameObject.SetActive(false);
        }
    }

}
