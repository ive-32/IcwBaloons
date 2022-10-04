using UnityEngine;

namespace IcwBaloons
{
    public class IcwBonusBaloon : IcwBaseBaloon
    {
        protected override void Awake()
        {
            Color[] colors = { Color.magenta, Color.red, Color.cyan };
            //Any Baloon except Last Particle system object
            int currball = Random.Range(0, this.transform.childCount - 1);
            this.transform.GetChild(currball).gameObject.SetActive(true);
            balooncolor = colors[currball];
            SetBurstColor(balooncolor);
            speed = Random.Range(1.5f, 2f);
            base.Awake();
        }

        


        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            IcwScores.instance.AddScores(50);
            IcwSplashText.instance.SplashText(this.transform.position, "+50", "U've Got It!");
        }
    }
}
