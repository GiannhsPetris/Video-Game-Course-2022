using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Utils;
using GoblinHeist.SceneManagement;
using System;
using TMPro;

namespace GoblinHeist.UI
{

    public class MainMenuUi : MonoBehaviour
    {
         LazyValue<SavingWrapper> savingWrapper;

         [SerializeField] TMP_InputField newGameNameField;

         private void Awake() 
         {
            savingWrapper = new LazyValue<SavingWrapper>(GetSavingWrapper);
         }

        private SavingWrapper GetSavingWrapper()
        {
            return FindObjectOfType<SavingWrapper>();
        }

        public void ContinueGame()
        {
            savingWrapper.value.ContinueGame();
        }

        public void NewGame()
        {
            savingWrapper.value.NewGame(newGameNameField.text);
        }

        public void QuitGame()
        {
            Application.Quit();
            print("quit");
        }
    }
}
