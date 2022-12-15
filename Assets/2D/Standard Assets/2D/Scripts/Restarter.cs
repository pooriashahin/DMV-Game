using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        [SerializeField] GameObject highscoreBoard;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Car")
            {
                Time.timeScale = 0.0f;
                highscoreBoard.SetActive(true);
            }
        }
    }
}
