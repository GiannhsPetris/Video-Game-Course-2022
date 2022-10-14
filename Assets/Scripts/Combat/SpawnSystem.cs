using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Course.WeightedRandom;
using Course.Attributes;

namespace Course.Combat
{
    public class SpawnSystem : MonoBehaviour
    {

        WeightedRandomizer weightedRandomizer;

        [SerializeField] private List<Transform> spawnPointList = new List<Transform>() { };


        int currentAlive;
        int spawnCounter;


        public void SpawnStart(int maxEnemies, List<WeightedValue> weightedValues)
        {
            weightedRandomizer = GetComponent<WeightedRandomizer>();
            StartCoroutine(Spawn(maxEnemies, weightedValues));
        }

        private IEnumerator Spawn(int maxEnemies, List<WeightedValue> weightedValues)
        {
            spawnCounter = 0;

            WaitForSeconds wait = new WaitForSeconds(3.5f);

            while (spawnCounter < maxEnemies)
            {
                int spawnIndex = Random.Range(0, spawnPointList.Count);
                GameObject enemy = weightedRandomizer.GetRandomValue(weightedValues);

                GameObject clone = GameObject.Instantiate(enemy, spawnPointList[spawnIndex]);

                //clone.GetComponents<Health>().

                spawnCounter++;

                yield return wait;
            }
        }
    }

}