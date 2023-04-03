using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World.HUD
{
    public class PauseHandler : MonoBehaviour
    {
        public void Pause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Continue()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Exit()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}

