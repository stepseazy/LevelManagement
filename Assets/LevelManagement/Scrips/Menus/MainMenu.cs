using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement {

    public class MainMenu : Menu<MainMenu>
    {

        public void OnPlayPressed()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadNextLevel();
            }
        }

        public void OnSettingsPressed()
        {
            if (MenuManager.Instance != null && SettingsMenu.Instance != null)
                MenuManager.Instance.OpenMenu(SettingsMenu.Instance);
            else {
                if(MenuManager.Instance==null)
                print("no instance menumanager");

                if (SettingsMenu.Instance == null)
                    print("no instance settingsMenu");
            }
        }

        public void OnCreditsPressed()
        {
            if (MenuManager.Instance != null && CreditScreen.Instance != null)
                MenuManager.Instance.OpenMenu(CreditScreen.Instance);
        }
        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}
