using UnityEngine;


namespace IcwBaloons
{
    public class IcwBaloon : IcwBaseBaloon
    {
        
        protected override void Awake()
        {
            balooncolor = IcwColors.GetRandomColor();
            GameObject BaloonSprite;
            BaloonSprite = this.transform.Find("Baloon").gameObject;
            BaloonSprite.GetComponent<SpriteRenderer>().color = balooncolor;
            SetBurstColor(balooncolor);
            speed = Random.Range(0.8f, 1.5f);
            base.Awake();
        }


        

        protected override void OnMouseDown()
        {
            IcwBonusGenerator.Instance.gameObject.BroadcastMessage("BaloonWasBurst", balooncolor);
            IcwScores.instance.AddScores(1);
            IcwSplashText.instance.SplashText(this.transform.position, "+1", "");
            base.OnMouseDown();
        }

    }
}
