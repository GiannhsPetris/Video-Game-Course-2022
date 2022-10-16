using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoblinHeist.Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] UnityEvent onHit;
        public void OnHit()
        {
            onHit.Invoke();
            print("Weapon Hit " + gameObject.name);
        }
    }
}
