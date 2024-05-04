using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MazeGame
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public UnityEvent GameOverEvent;

        private void Awake()
        {
            instance = this;
        }
        [ContextMenu("Test GameOver Event")]
        void GameOver()
        {
            GameOverEvent.Invoke();
        }

        public static void AddGameOverEventListener(UnityAction action)
        {
            instance.GameOverEvent.AddListener(action);
        }
    }
}
