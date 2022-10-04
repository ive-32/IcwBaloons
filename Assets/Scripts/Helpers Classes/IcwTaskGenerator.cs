using UnityEngine;


namespace IcwBaloons
{
    public class IcwTaskGenerator : MonoBehaviour
    {
        public static IcwTaskGenerator Instance;
        bool newBonusNeed;
        float awaitNewTaskTime;
        public float newbonusdeltatime;
        public GameObject BonusPrefab;
        GameObject bonustask;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            newBonusNeed = false;
            awaitNewTaskTime = Time.realtimeSinceStartup;
            newbonusdeltatime = Random.Range(20, 25);
            bonustask = null;
        }

        void GenerateNewBonus()
        {
            bonustask = Instantiate(BonusPrefab, this.transform);
            newBonusNeed = false;
            newbonusdeltatime = 100000;
        }

        private bool CalcBonusTaskNeed()
        {
            float deltatime = Time.realtimeSinceStartup - awaitNewTaskTime;

            return bonustask == null && newbonusdeltatime < deltatime;
        }

        private void Update()
        {
            if (bonustask == null && newbonusdeltatime == 100000)
            {
                awaitNewTaskTime = Time.realtimeSinceStartup;
                newbonusdeltatime = Random.Range(40, 120);
            }
            newBonusNeed = CalcBonusTaskNeed();
            if (newBonusNeed) GenerateNewBonus();
        }


    }
}
