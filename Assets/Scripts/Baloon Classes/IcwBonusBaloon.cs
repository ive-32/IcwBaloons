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

            IcwBaseBaloon bb = this.GetComponent<IcwBaseBaloon>();
            Debug.LogWarning(bb.name);
        }

        


        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            IcwScores.instance.AddScores(50);
            IcwBonuses bonus = new IcwBonuses();
            IcwSplashText.instance.SplashText(this.transform.position, bonus.GetBonusDescribe(), bonus.GetBonusText());
            bonus.BonusAction();

        }
    }
}
