using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoblinHeist.WeightedRandom;
using GoblinHeist.Attributes;

namespace GoblinHeist.Combat
{
    public class SpawnSystem : MonoBehaviour
    {

        WeightedRandomizer weightedRandomizer;

        [SerializeField] private List<Transform> spawnPointList = new List<Transform>() { };
        [SerializeField] float seconds = 4f;


        int currentAlive;
        int spawnCounter;


        public void SpawnStart(int maxEnemies, List<WeightedValue> weightedValues)
        {
            weightedRandomizer = GetComponent<WeightedRandomizer>();
            StartCoroutine(Spawn(maxEnemies, weightedValues, seconds));
        }

        private IEnumerator Spawn(int maxEnemies, List<WeightedValue> weightedValues, float seconds)
        {
            spawnCounter = 0;

            WaitForSeconds wait = new WaitForSeconds(seconds);

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