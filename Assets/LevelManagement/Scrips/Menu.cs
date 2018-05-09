using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement {
    public abstract class Menu<T> : Menu where T : Menu<T> {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        protected virtual void Awake() {
            print("type+ "+this.GetType());
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else {
                _instance = (T)this;
            }
        }

        protected virtual void OnDestroy() {
            _instance = null;
        }
    }
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        MenuManager menuManager;
        void Start (){
            menuManager = MenuManager.Instance;
        }

        public virtual void OnBackPressed() {
            menuManager.CloseMenu();
        }

    }
}

