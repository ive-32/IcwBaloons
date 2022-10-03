using System.Collections.Generic;
using UnityEngine;


namespace IcwBaloons
{
    public class IcwBonusGenerator : MonoBehaviour
    {
        public static IcwBonusGenerator Instance;
        bool newBonusNeed;
        float lastbonustasktime;
        public GameObject BonusPrefab;
        GameObject bonustask;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            newBonusNeed = false;
            lastbonustasktime = Time.realtimeSinceStartup;
            bonustask = null;
        }

        void GenerateNewBonus()
        {
            bonustask = Instantiate(BonusPrefab);
            bonustask.transform.SetParent(this.transform);
            bonustask.transform.localPosition = new Vector3(1, IcwGame.sizey, 0);
            newBonusNeed = false;
            lastbonustasktime = Time.realtimeSinceStartup;
        }

        private bool CalcBonusTaskNeed()
        {
            float deltatime = Time.realtimeSinceStartup - lastbonustasktime;
            return bonustask==null && Random.Range(0.0f, 60.0f) < deltatime / 2;
        }

        private void Update()
        {
            newBonusNeed = CalcBonusTaskNeed();
            if (newBonusNeed) GenerateNewBonus();
        }


    }
}
