using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Course.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Awake() 
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        private void Update() 
        {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());
        }
    }
}