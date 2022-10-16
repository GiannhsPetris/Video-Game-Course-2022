using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GoblinHeist.Stats
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experience;

        private void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}", experience.GetPoints());
        }
    }
}