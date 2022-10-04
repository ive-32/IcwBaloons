using UnityEngine;


namespace IcwBaloons
{ 
    public class IcwBonusTask : IcwBaseHelper
    {
        const int bonuslength = 3;
        Color[] colors = new Color[bonuslength];
        GameObject[] baloons = new GameObject[bonuslength];
        GameObject[] completedsquares = new GameObject[bonuslength];
        public GameObject[] bonuses;
        Animation anim;
        float lasttrembletime;
        

        GameObject bonusprefab;

        private void Awake()
        {
            anim = this.GetComponent<Animation>();
        }
        public override void Start()
        {
            base.Start();
            if (bonuses.Length <= 0)
            {   // Bonuses prefabs not initialized in unity
                Debug.LogWarning("Bonuses prefabs not initialized in unity");
                Object.Destroy(this.gameObject);
                return; 
            }

            bonusprefab = bonuses[Random.Range(0, bonuses.Length)];
            
            for (int i = 0; i < bonuslength; i++)
            {
                colors[i] = IcwColors.GetRandomColor();
                baloons[i] = this.transform.Find("Baloon" + i.ToString()).gameObject;
                completedsquares[i] = this.transform.Find("Square" + i.ToString()).gameObject;
                baloons[i].GetComponent<SpriteRenderer>().color = colors[i];
            }
            anim.Play("BonusTaskAppear");
            lasttrembletime = Time.realtimeSinceStartup;
        }


        public override void Update()
        {
            base.Update();
            if (Random.Range(0, 100) < 1 && Time.realtimeSinceStartup - lasttrembletime > 10)
            {
                anim.Play("BonusTaskTremble");
                lasttrembletime = Time.realtimeSinceStartup;
            }
        }

        public void BaloonWasBurst(Color acolor)
        {
            int totalcompelted = 0;
            for (int i = 0; i < bonuslength; i++)
            {
                if (acolor == colors[i] && !completedsquares[i].activeSelf)
                {
                    completedsquares[i].SetActive(true);
                    break;
                }
            }
            for (int i = 0; i < bonuslength; i++)
                if (completedsquares[i].activeSelf) totalcompelted++;
            if (totalcompelted == bonuslength)
            { // Bonus task complete
                GameObject gm = GameObject.Find(bonusprefab.name + "(Clone)");
                if (gm != null) gm.GetComponent<IcwBaseHelper>().ResetTTL();
                else Instantiate(bonusprefab);
                IcwSplashText.instance.SplashText(new Vector3(IcwGame.sizex / 2.0f, 1.0f, 0), "+100", "U've Got It!", true);
                IcwScores.instance.AddScores(100);
                Object.Destroy(this.gameObject);
            }

            // Old code step by step bonus 
            /*if (currPositionInBonus >= bonuslength) return;
            
            if (acolor != colors[currPositionInBonus])
            {   // wrong color burst
                Object.Destroy(this.gameObject);
                return;
            }
            
            // Right color - mark it in preafb        
            completedsquares[currPositionInBonus].SetActive(true);

            if (currPositionInBonus == bonuslength - 1)
            { // Bonus task complete
                Instantiate(bonusprefab);
                Object.Destroy(this.gameObject);
            }
            currPositionInBonus++;*/
        }
    }
}
