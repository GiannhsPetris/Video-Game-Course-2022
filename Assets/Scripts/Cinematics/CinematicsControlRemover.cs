using UnityEngine;
using UnityEngine.Playables;
using GoblinHeist.Core;
using GoblinHeist.Control;
using GoblinHeist.SceneManagement;

namespace GoblinHeist.Cinematics
{
    public class CinematicsControlRemover : MonoBehaviour
    {
        GameObject core;
        GameObject player;

        private void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
            player = GameObject.FindWithTag("Player");
        }

        void DisableControl(PlayableDirector pd)
        {
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //print("enter");
            //player.GetComponent<Fighter>().enabled = false;
            //player.SetActive(false);
        }

        void EnableControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerController>().enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Fader fader = FindObjectOfType<Fader>();
            fader.FadeOutImmediate();
            fader.FadeIn(0.5f);
            //player.GetComponent<Fighter>().enabled = true;
            //player.SetActive(true);
        }
    }
}