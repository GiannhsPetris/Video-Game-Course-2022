using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Course.Saving;
using UnityEngine.SceneManagement;

namespace Course.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {

        private const string Key = "currentsaveName";
        [SerializeField] float fadeInTime = 0.2f;
        [SerializeField] float fadeOutTime = 0.2f;

        public void ContinueGame () 
        {
            if (!PlayerPrefs.HasKey(Key)) return;
            if (!GetComponent<SavingSystem>().SaveFileExists(GetCurrentSave())) return;
            StartCoroutine(LoadLastScene());    
        }

        public void NewGame(string saveFile)
        {
            if (String.IsNullOrEmpty(saveFile)) return;
            SetCurrentSave(saveFile);
            StartCoroutine(LoadFirstScene());
        } 

        public void LoadGame(string saveFile)
        {
            SetCurrentSave(saveFile);
            ContinueGame();
        }

        IEnumerator  LoadLastScene() {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);

            yield return GetComponent<SavingSystem>().LoadLastScene(GetCurrentSave());
            
            yield return fader.FadeIn(fadeInTime);
        }

        public void LoadMenu()
        {
            StartCoroutine(LoadMenuScene());
        }

        IEnumerator LoadFirstScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);

            yield return SceneManager.LoadSceneAsync(1);

            yield return fader.FadeIn(fadeInTime);
        }

        IEnumerator LoadMenuScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);

            yield return SceneManager.LoadSceneAsync(0);

            yield return fader.FadeIn(fadeInTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        private void SetCurrentSave(string saveFile)
        {
            PlayerPrefs.SetString(Key, saveFile);
        }

         private string GetCurrentSave()
        {
            return PlayerPrefs.GetString(Key);
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(GetCurrentSave());
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(GetCurrentSave());
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(GetCurrentSave());
        }

        public IEnumerable<string> Listsaves()
        {
            return GetComponent<SavingSystem>().Listsaves();
        }
    }
}
