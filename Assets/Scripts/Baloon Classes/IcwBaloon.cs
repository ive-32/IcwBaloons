using UnityEngine;


namespace IcwBaloons
{
    public class IcwBaloon : IcwBaseBaloon
    {

        public void SetColor(Color acolor)
        {
            balooncolor = acolor;
            SetBurstColor(acolor);
            GameObject BaloonSprite;
            BaloonSprite = this.transform.Find("Baloon").gameObject;
            BaloonSprite.GetComponent<SpriteRenderer>().color = balooncolor;
        }


        protected override void Awake()
        {
            balooncolor = IcwColors.GetRandomColor();
            SetColor(balooncolor);
            speed = Random.Range(0.8f, 1.5f);
            base.Awake();
        }


        

        protected override void OnMouseDown()
        {
            IcwTaskGenerator.Instance.gameObject.BroadcastMessage("BaloonWasBurst", balooncolor);
            IcwScores.instance.AddScores(1);
            IcwSplashText.instance.SplashText(this.transform.position, "+1", "");
            base.OnMouseDown();
        }

    }
}
