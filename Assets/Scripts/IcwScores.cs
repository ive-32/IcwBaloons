using UnityEngine;
using TMPro;

namespace IcwBaloons
{
    public class IcwScores :MonoBehaviour
    {
        public static IcwScores instance;
        public int value;
        private int displayvalue;
        float valueChangeSpeed;
        TextMeshProUGUI tmp;

        private void Awake()
        {
            instance = this;
            GameObject canvas = this.transform.Find("Canvas").gameObject;
            GameObject scorevalue = canvas.transform.Find("Value").gameObject;
            tmp = scorevalue.GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            value = 0;
            displayvalue = 0;
            valueChangeSpeed = 10;
            //this.transform.position = new Vector3(0.3f, 0, 0);
            ShowScore();    
        }

        private void Update()
        {
            if (displayvalue != value)
            {
                int scoreschange = Mathf.RoundToInt(Mathf.Clamp(value - displayvalue, -1, 1) * valueChangeSpeed * Time.deltaTime);
                if (scoreschange == 0 || Mathf.Abs(scoreschange) > Mathf.Abs(value - displayvalue))
                    displayvalue = value;
                else
                    displayvalue += scoreschange;
                ShowScore();
            }
        }
        public void AddScores(int avalue)
        {
            value += avalue;
        }

        void ShowScore()
        {
            if (tmp == null) return;
            tmp.text = displayvalue.ToString();
        }
    }
}
