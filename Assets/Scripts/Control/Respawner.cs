using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using GoblinHeist.Attributes;
using GoblinHeist.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

namespace GoblinHeist.Control
{
    public class Respawner : MonoBehaviour
    {
        [SerializeField] Transform respawnLocation;
        [SerializeField] float respawnDelay = 3f;
        [SerializeField] float fadeTime = 3f;
        [SerializeField] float healthRegenPercentage = 30f;
        [SerializeField] float enemyHealthRegenPercentage = 30f;


        private void Awake() 
        {
            GetComponent<Health>().onDie.AddListener(Respawn);
        }

        private void Start() 
        {
            if (GetComponent<Health>().IsDead()) Respawn();
        }


        private void Respawn()
        {
            StartCoroutine(RespawnRoutine());
        }


        private IEnumerator RespawnRoutine()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            //savingWrapper.Save();

            yield return new WaitForSeconds(respawnDelay);

            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeTime);

            RespawnPlayer();
            ResetEnemies();

            //savingWrapper.Save(); 
            yield return fader.FadeIn(fadeTime);
        }

        private void ResetEnemies()
        {
           foreach (AIController enemyController in FindObjectsOfType<AIController>())
           {
                Health health = enemyController.GetComponent<Health>();

                if (health && !health.IsDead())
                {
                    enemyController.Reset();
                    health.Heal(health.GetMaxHealthPoints() * enemyHealthRegenPercentage / 100);
                }
           }
        }

        private void RespawnPlayer()
        {
            Vector3 positionDelta = respawnLocation.position - transform.position;

            GetComponent<NavMeshAgent>().Warp(respawnLocation.position);
            Health health = GetComponent<Health>();
            health.Heal(health.GetMaxHealthPoints() * healthRegenPercentage / 100);

            ICinemachineCamera activeVirtualCamera = FindObjectOfType<CinemachineBrain>().ActiveVirtualCamera;
            if (activeVirtualCamera.Follow == transform)
            {
                activeVirtualCamera.OnTargetObjectWarped(transform, positionDelta);
            }
        }
    }
}
