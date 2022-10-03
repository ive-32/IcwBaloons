using UnityEditor.Tilemaps;
using UnityEngine;

namespace IcwBaloons
{
    public class IcwBadBoy : IcwBaseBonus
    {
        GameObject baloons;
        Animation anim;
        public override void Start()
        {
            ttldefault = 45;
            base.Start();
            baloons = GameObject.Find("Baloons").gameObject;
            anim = this.GetComponent<Animation>();
           
        }

        public override void Update()
        {
            base.Update();
            if (baloons.transform.childCount >0 && Random.Range(0, 100)<10 && !anim.isPlaying)
            {
                GameObject targetbaloon;
                int inumiterations = 0;
                do
                {
                    targetbaloon = baloons.transform.GetChild(Random.Range(0, baloons.transform.childCount)).gameObject;
                    inumiterations++;
                    if (inumiterations>5) return;
                } while (targetbaloon.transform.position.y < 3);
                float anglevariable = targetbaloon.transform.position.y - this.transform.position.y;

                if (Mathf.Abs(anglevariable) < 2) 
                    anim.Play("SlingShotForward");
                else
                {
                    if (anglevariable > 0) anim.Play("SlingShotUp");
                    if (anglevariable < 0) anim.Play("SlingShotDown");
                }
                targetbaloon.GetComponent<IcwBaloon>().Burst();
            }
        }
    }
}
