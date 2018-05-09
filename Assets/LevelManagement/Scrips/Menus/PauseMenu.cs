using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        [SerializeField]
        private int mainMenuIndex = 0;
        public void OnResumePressed()
        {
            if (GameManager.Instance != null)
            {
                Time.timeScale = 1;
                base.OnBackPressed();
            }
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(mainMenuIndex);
            if (MenuManager.Instance != null) {
                MenuManager.Instance.OpenMenu(MainMenu.Instance);
            }
        }
        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }
}