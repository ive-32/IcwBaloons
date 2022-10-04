using UnityEngine;


namespace IcwBaloons
{
    public class IcwBaloonGenerator :MonoBehaviour
    {
        private bool newBaloonNeed;
        public GameObject BaloonPrefab;
        public GameObject BonusBaloonPrefab;

        private void Start()
        {
            newBaloonNeed = true;
        }

        void GenerateNewBaloon()
        {
            
            GameObject newb;
            GameObject newbprefab = BaloonPrefab;
            if (Random.Range(0, 100) < 50) newbprefab = BonusBaloonPrefab;
            float x = Random.Range(0.0f, (float)IcwGame.sizex);
            newb = Instantiate(newbprefab, new Vector3(x, 1, 0), Quaternion.identity, this.transform);
            newBaloonNeed = false;
        }

        private void Update()
        {
            if (this.transform.childCount < 5 )
            {
                newBaloonNeed = Random.Range(0, 100) < 3;
                if (newBaloonNeed) GenerateNewBaloon();
            }
            if (this.transform.childCount == 0) newBaloonNeed = true;
        }
    }
}
