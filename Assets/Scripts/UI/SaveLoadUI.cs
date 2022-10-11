using System.Collections;
using System.Collections.Generic;
using Course.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Course.UI
{
    public class SaveLoadUI : MonoBehaviour
    {
        [SerializeField] Transform contentRoot;
        [SerializeField] GameObject buttonPrefab;

        private void OnEnable() 
        {
            foreach (Transform child in contentRoot)
            {
                Destroy(child.gameObject);
            }

            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();

            if (savingWrapper == null) return;
            foreach (string save in savingWrapper.Listsaves())
            {
                GameObject buttonInstance = Instantiate(buttonPrefab, contentRoot);  
                TMP_Text textComponent = buttonInstance.GetComponentInChildren<TMP_Text>();
                textComponent.text = save;

                Button button = buttonInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    savingWrapper.LoadGame(save);
                });
            }
        }
    }
}
