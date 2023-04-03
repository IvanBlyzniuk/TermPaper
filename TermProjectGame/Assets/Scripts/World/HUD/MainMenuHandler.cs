using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World.HUD
{
    public class MainMenuHandler : MonoBehaviour
    {
        public void Continue()
        {
            if(!PlayerPrefs.HasKey("currentLevel"))
            {
                NewGame();
                return;
            }
            SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
        }
        public void NewGame()
        {
            PlayerPrefs.SetString("currentLevel", "Level1");
            PlayerPrefs.SetInt("currentRoom", 0);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}
