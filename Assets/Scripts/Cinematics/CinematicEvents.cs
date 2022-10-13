using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course.Cinematics
{
    public class CinematicEvents : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] TMPro.TMP_Text textField;
        [SerializeField] string[] dialogues;

        int index = 0;


        public void EnableCanvas()
        {
            canvas.SetActive(true);
        }

        public void DisableCanvas()
        {
            canvas.SetActive(false);
        }

        public void ShowNextText()
        {
            if (index > dialogues.Length) return;
            textField.text = dialogues[index];
            index ++;
        }

        public void FirstWave()
        {

        }

        public void SecondWave()
        {

        }

        public void Finalwave()
        {

        }
    }
}
