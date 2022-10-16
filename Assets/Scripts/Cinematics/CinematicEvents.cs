using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoblinHeist.Combat;
using GoblinHeist.SceneManagement;

namespace GoblinHeist.Cinematics
{
    public class CinematicEvents : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] GameObject pauseCanvas;
        [SerializeField] TMPro.TMP_Text textField;
        [SerializeField] string[] dialogues;

        int index = 0;



        public void EnableCanvas()
        {
            canvas.SetActive(true);
            pauseCanvas.SetActive(false);
        }

        public void DisableCanvas()
        {
            canvas.SetActive(false);
            pauseCanvas.SetActive(true);
        }

        public void ShowNextText()
        {
            print(index);
            if (index > dialogues.Length) return;
            textField.text = dialogues[index];
            index ++;
        }

        public void ResetIndex()
        {
            index = 0;
        }

        public void Quit()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            if (savingWrapper != null) print("good");
            savingWrapper.LoadMenu();
        } 
    }
}
