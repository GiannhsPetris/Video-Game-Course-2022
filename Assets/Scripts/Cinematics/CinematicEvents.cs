using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Course.Combat;

namespace Course.Cinematics
{
    public class CinematicEvents : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] GameObject pauseCanvas;
        [SerializeField] TMPro.TMP_Text textField;
        [SerializeField] string[] dialogues;

        int index = 0;

        [SerializeField] WaveSystem waveSystem ;


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
            if (index > dialogues.Length) return;
            textField.text = dialogues[index];
            index ++;
        }

        // public void FirstWaveEvent()
        // {
        //     waveSystem.FirstWave();
        // }

        // public void SecondWaveEvent()
        // {
        //    waveSystem.SecondWave();
        // }

        // public void FinalwaveEvent()
        // {
        //     waveSystem.Finalwave();
        // }

        
    }
}
