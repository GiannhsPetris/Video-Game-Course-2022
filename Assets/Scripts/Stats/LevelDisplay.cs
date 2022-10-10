using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Course.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats baseStats;

        private void Awake()
        {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }

        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}", baseStats.GetLevel());
        }
    }
}