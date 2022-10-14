using System.Collections;
using System.Collections.Generic;
using Course.Control;
using Course.SceneManagement;
using UnityEngine;

namespace Course.UI
{
    public class PauseMenu : MonoBehaviour
    {

        PlayerController playerController;

        private void Awake() 
        {
            playerController =  GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }


        private void OnEnable() 
        {
            if (playerController == null) return;
            Time.timeScale = 0;
            playerController.enabled = false;
        }

        private void OnDisable() 
        {
            if (playerController == null) return;
            Time.timeScale = 1;
            playerController.enabled = true;
        }


        public void Save()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.Save();
        }

        public void Quit()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.LoadMenu();
        }

        public void SaveAndQuit()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.Save();
            savingWrapper.LoadMenu();
        }
    }
}
