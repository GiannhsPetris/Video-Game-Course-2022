using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Course.Combat;
using Course.WeightedRandom;

namespace Course.Combat
{
    public class WaveSystem : MonoBehaviour
    {
        [SerializeField] GameObject[] pickups;
        [SerializeField] GameObject[] pickups2;
        [SerializeField] GameObject boss;

        [SerializeField] List<WeightedValue> enemies1;
        [SerializeField] List<WeightedValue> enemies2;
        [SerializeField] List<WeightedValue> enemies3;

        [SerializeField] PlayableDirector playableDirectorEnd;
        [SerializeField] PlayableDirector playableDirectorEmpty;
        [SerializeField] PlayableDirector playableDirectorBoss;


        [SerializeField] int wave1Length;
        [SerializeField] int wave2Length;
        [SerializeField] int wave3Length;


        [SerializeField] int totalLeft = 0;
        bool wave2Started, wave3Started, end;
        SpawnSystem spawnSystem;
        //private int killcounter;

        private void Start()
        {
            //killcounter =0;

            totalLeft = wave1Length + wave2Length + wave3Length;
            //print(totalLeft.ToString());

            //totalLeft = enemies1.Count + enemies2.Count + enemies3.Count;

            wave2Started = false;
            wave3Started = false;
            end = false;

            spawnSystem = GetComponent<SpawnSystem>();
            //cutscene 1st wave
            //spawn enemies
            //if(spawnSystem != null) FirstWave();
           
        }

        private void Update()
        {
            //print(totalLeft.ToString());
            //print(killcounter.ToString());
           if (totalLeft == wave2Length + wave3Length && !wave2Started)
           {
                wave2Started = true;
                //spawn pickups
                SpawnItems(pickups);
                //play empty cutscene for 10s
                playableDirectorEmpty.Play();
                //then spawn enemies

           }
           else if (totalLeft == wave3Length && !wave3Started)
           {
                wave3Started = true;
                // //spawn pickups
                SpawnItems(pickups2);
                // //play empty cutscene for 10s
                playableDirectorBoss.Play();
                // //play boss cutscene
                // //then spawn enemies
            }
           else if (totalLeft == 0 && !end)
           {
                end = true;
                // //play ending cutscene 
                playableDirectorEnd.Play();
                // //go to menu
           }
        }

        //called by first cutscene
        public void FirstWave()
        {
            spawnSystem.SpawnStart(wave1Length, enemies1);
            print(1);
        }


        //called by empty
        public void SecondWave()
        {
            print(2);
            spawnSystem.SpawnStart(wave2Length, enemies2);
        }

        //called by boss
        public void Finalwave()
        {
            totalLeft ++;
            boss.SetActive(true);
            print(3);
            spawnSystem.SpawnStart(wave3Length, enemies3);
        }

        public void SpawnItems(GameObject[] pickups)
        {
            foreach (GameObject item in pickups)
            {
                item.SetActive(true);
            }
        }


        public void EnemyKilled()
        {
            totalLeft = totalLeft - 1;
            print(totalLeft.ToString());
           // killcounter ++;
            //print(killcounter.ToString());
        }
    }
}
