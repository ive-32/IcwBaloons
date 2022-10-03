using UnityEngine;


namespace IcwBaloons
{ 
    public class IcwBonusTask : MonoBehaviour
    {
        const int bonuslength = 3;
        Color[] colors = new Color[bonuslength];
        GameObject[] baloons = new GameObject[bonuslength];
        GameObject[] completedsquares = new GameObject[bonuslength];
        public GameObject[] bonuses;
        int currPositionInBonus;

        GameObject bonusprefab; 

        private void Start()
        {
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
            currPositionInBonus = 0;
        }


        public void BaloonWasBurst(Color acolor)
        {

            if (currPositionInBonus >= bonuslength) return;
            
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
            currPositionInBonus++;
        }
    }
}
