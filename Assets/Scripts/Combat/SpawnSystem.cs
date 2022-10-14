using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Course.WeightedRandom;

namespace Course.Combat
{
    public class SpawnSystem : MonoBehaviour
    {

        WeightedRandomizer weightedRandomizer;

        [Header("Lists")]
        [SerializeField] private List<Transform> spawnPointList = new List<Transform>() { };

       


        [Header("Stats")]
        [SerializeField] private int currentMax = 5;
        [SerializeField] private int leftToSpawn;

        [SerializeField] private float timeToSpawn = 15;
        [SerializeField] private float currentTime = 0;


        int currentAlive;
        int spawnCounter;


        //Enemy enemy;


        // private void Update() 
        // {
        //     if (currentTime > 0)
        //     {
        //         currentTime -= Time.deltaTime;
        //     }
        //     else
        //     {
        //         CheckSpawn(goalList, spawnPointList);
        //         currentTime = timeToSpawn;
        //     }
        // }


        // public void CheckSpawn(List<Transform> goalList, List<Transform> spawnPointList, List<WeightedValue> weightedValues)
        // {
        //     leftToSpawn = currentMax - currentAlive;
        //     if (leftToSpawn > 0) StartCoroutine(Spawn(leftToSpawn, spawnPointList, weightedValues));

        // }

        public void SpawnStart(int maxEnemies, List<WeightedValue> weightedValues)
        {
            weightedRandomizer = GetComponent<WeightedRandomizer>();
            StartCoroutine(Spawn(maxEnemies, weightedValues));
        }

        private IEnumerator Spawn(int maxEnemies, List<WeightedValue> weightedValues)
        {
            spawnCounter = 0;

            WaitForSeconds wait = new WaitForSeconds(1.5f);

            while (spawnCounter < maxEnemies)
            {
                int spawnIndex = Random.Range(0, spawnPointList.Count);
                GameObject enemy = weightedRandomizer.GetRandomValue(weightedValues);

                GameObject clone = GameObject.Instantiate(enemy, spawnPointList[spawnIndex]);
                //currentAlive++;
                spawnCounter++;

                yield return wait;
            }
        }

        // public void DeathOccured()
        // {
        //     currentAlive--;
        // }
    }

}