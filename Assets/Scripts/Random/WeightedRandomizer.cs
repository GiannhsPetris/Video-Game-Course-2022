using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course.WeightedRandom
{
    public class WeightedRandomizer : MonoBehaviour
    {
        

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //string randomValue = GetRandomValue(weightedValues);
                //Debug.Log(randomValue ?? "No entries found");
            }
        }

        public GameObject GetRandomValue(List<WeightedValue> weightedValueList)
        {
            GameObject output = null;

            //Getting a random weight value
            var totalWeight = 0;
            foreach (var entry in weightedValueList)
            {
                totalWeight += entry.weight;
            }
            var rndWeightValue = Random.Range(1, totalWeight + 1);

            //Checking where random weight value falls
            var processedWeight = 0;
            foreach (var entry in weightedValueList)
            {
                processedWeight += entry.weight;
                if (rndWeightValue <= processedWeight)
                {
                    output = entry.value;
                    break;
                }
            }

            return output;
        }
    }

}