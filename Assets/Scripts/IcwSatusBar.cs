using System.Runtime.CompilerServices;
using UnityEngine;


namespace IcwBaloons
{
    public class IcwSatusBar : MonoBehaviour
    {
        GameObject statusbar;
        SpriteRenderer sr;

        private void Awake()
        {
            sr = this.GetComponent<SpriteRenderer>();
            
        }

        public void SetStatusBar(float value)
        {   // First half: change to yellow from green 
            // Scond half: change to red from yellow
            Color cl = Color.yellow;
            if (value > 0.5f)
                cl.r = (2.0f - value * 2.0f);
            if (value < 0.5f)
                cl.g = (value * 2.0f);
            
            if (sr != null) sr.color = cl;

            this.transform.localScale = new Vector3(value, 1, 1);
        }
    }
}
