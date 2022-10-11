using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course.Core
{
    public class DestroyAfterEffect : MonoBehaviour
    {

        [SerializeField] GameObject targetToDestroy = null;
        void Update()
        {
            if (!GetComponent<ParticleSystem>().IsAlive())
            {
                if (targetToDestroy != null) Destroy(targetToDestroy);
                else Destroy(gameObject);
                
            }
        }
    }
}