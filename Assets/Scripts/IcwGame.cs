using UnityEngine;


namespace IcwBaloons
{
    internal class IcwGame : MonoBehaviour
    {
        [System.NonSerialized] public static int sizex = 3;
        [System.NonSerialized] public static int sizey = 12;
        [System.NonSerialized] public static IcwGame instance;
        [System.NonSerialized] public static float gameBaseSpeed;
        float ttlspeed;
        [System.NonSerialized] public int lostballs;
        [System.NonSerialized] public int maxlostballs;
        public GameObject Lanternprefab;
        public GameObject Trollprefab;

        public void SetGameSpeed(float aspeed)
        {
            gameBaseSpeed = aspeed;
            ttlspeed = 30;
        }

        public void StartGame()
        {
            gameBaseSpeed = 1.0f;
            lostballs = 0;
            maxlostballs = 10;
        }

        private void Start()
        {
            instance = this;
            StartGame();
            Instantiate(Trollprefab);
        }

        private void Update()
        {
            if (ttlspeed>0)
            {
                ttlspeed -= Time.deltaTime;
                if (ttlspeed <= 0)
                {
                    ttlspeed = 0;
                    gameBaseSpeed = 1.0f;
                }
            }
        }
    }
}
