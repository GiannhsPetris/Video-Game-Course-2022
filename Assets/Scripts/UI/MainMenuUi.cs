using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Utils;
using Course.SceneManagement;
using System;

namespace Course.UI
{

    public class MainMenuUi : MonoBehaviour
    {
         LazyValue<SavingWrapper> savingWrapper;

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
    }
}
