using UnityEngine;
using TMPro;

namespace IcwBaloons
{
    public class IcwLostBalls :MonoBehaviour
    {
        public static IcwLostBalls instance;
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
            ShowLostBalls();    
        }

       
        public void ShowLostBalls()
        {
            if (tmp == null) return;
            tmp.text = IcwGame.instance.lostballs + " / " + IcwGame.instance.maxlostballs;
        }
    }
}
