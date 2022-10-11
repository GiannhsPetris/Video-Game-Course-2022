using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Course.Saving;
using Course.Stats;
using Course.Core;
using System;
using GameDevTV.Utils;
using UnityEngine.Events;

namespace Course.Attributes
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float regenerationPercentage = 70;
        [SerializeField] TakeDamageEvent takeDamage;

        public UnityEvent onDie;

        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {

        }



        LazyValue<float> healthPoints;
        bool wasDeadLastFrame = false;


        private void Awake() 
        {
            healthPoints = new LazyValue<float>(GetInitialHealth);    
        }

        private float GetInitialHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        internal void Heal(float healthToRestore)
        {
            healthPoints.value = Mathf.Min(healthPoints.value + healthToRestore, GetMaxHealthPoints());
            UpdateState();
        }

        private void Start() 
        {
            healthPoints.ForceInit();
        }

        private void OnEnable() 
        {
            GetComponent<BaseStats>().onLevelUp += RegenerateHealth;
        }

        private void OnDisable() 
        {
            GetComponent<BaseStats>().onLevelUp -= RegenerateHealth;
        }

      
        public bool IsDead()
        {
            return healthPoints.value <= 0;
        }


        public void TakeDamage(GameObject instigator, float damage)
        {
            healthPoints.value = Mathf.Max(healthPoints.value - damage, 0);

            if (IsDead())
            {
                onDie.Invoke();
                AwardExperience(instigator);
            }
            else takeDamage.Invoke(damage);

            UpdateState();
        }

        public float GetHealthPoints(){
            return healthPoints.value;
        }

        public float GetMaxHealthPoints(){
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) return;

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.ExperienceReward));
        }

        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (regenerationPercentage / 100);
            healthPoints.value = Mathf.Max(healthPoints.value, regenHealthPoints);
        }

        public float GetPercentage()
        {
            return 100 * GetFraction();
        }

        public float GetFraction()
        {
            return healthPoints.value / GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void UpdateState()
        {
            if(!wasDeadLastFrame && IsDead())
            {
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }
            
            if (wasDeadLastFrame && !IsDead())
            {
                GetComponent<Animator>().Rebind();
            }

            wasDeadLastFrame = IsDead();
        }

        public object CaptureState()
        {
            return healthPoints.value;
        }

        public void RestoreState(object state)
        {
            healthPoints.value = (float)state;

            UpdateState();
        }

    }
}