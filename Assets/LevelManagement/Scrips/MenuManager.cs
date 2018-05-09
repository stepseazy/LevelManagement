﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement {
    public class MenuManager : MonoBehaviour
    {
        public MainMenu mainMenuPrefab;
        public SettingsMenu settingsMenuPrefab;
        public CreditScreen creditsScreenPrefab;

        [SerializeField]
        private Transform _menuParent;

        private Stack<Menu> _menuStack = new Stack<Menu>();

        private static MenuManager _instance;

        public static MenuManager Instance { get { return _instance; }   }

        private void Awake() {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else {
                _instance = this;
                InitializeMenus();
            } 
        }

        private void OnDestroy() {
            if (_instance == this) {
                _instance = null;
            }
        }

        private void InitializeMenus() {
            if (_menuParent == null) {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }

            Menu[] menuPrefabs = {mainMenuPrefab, settingsMenuPrefab, creditsScreenPrefab };


            foreach (Menu prefab in menuPrefabs) {
                if (prefab != null) {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.GetComponent<Canvas>().enabled=false;
                    }
                    else {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }
        public void OpenMenu(Menu menuInstance) {
            if (menuInstance == null) {
                Debug.LogWarning("MENUMANAGER OpenMenu error: invalid menu");
                return;
            }
            if (_menuStack.Count > 0) {
                foreach (Menu menu in _menuStack) {
                    menu.gameObject.GetComponent<Canvas>().enabled = false;
                }
            }
            menuInstance.gameObject.GetComponent<Canvas>().enabled = true;
            _menuStack.Push(menuInstance);
        }
        public void CloseMenu() {
            if (_menuStack.Count == 0) {
                Debug.LogWarning("MENUMANAGER CloseMenu ERROR: No menus in stack!");
                return;
            };

            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.GetComponent<Canvas>().enabled = false;

            if (_menuStack.Count > 0) {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.GetComponent<Canvas>().enabled = true;
            }
        }
    }

}

