using UnityEngine;


namespace IcwBaloons
{
    public class IcwBaloonGenerator :MonoBehaviour
    {
        private bool newBaloonNeed;
        public GameObject BaloonPrefab;

        private void Start()
        {
            newBaloonNeed = true;
        }

        void GenerateNewBaloon()
        {
            GameObject newb;
            newb = Instantiate(BaloonPrefab);
            newb.transform.SetParent(this.transform);
            float x = Random.Range(0.0f, (float)IcwGame.sizex);
            newb.transform.localPosition = new Vector3(x, 1, 0);
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
