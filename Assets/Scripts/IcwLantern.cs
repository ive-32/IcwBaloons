
using UnityEngine;

namespace IcwBaloons
{
    public class IcwLantern : IcwBaseBonus
    {

        public override void Start()
        {
            base.Start();
            Animation appear = this.GetComponent<Animation>();
            appear.Play();
        }

        
        void OnTriggerEnter2D(Collider2D other)
        {
            IcwBaloon bl = other.gameObject.GetComponent<IcwBaloon>();
            if (bl != null) bl.Burst();
        }
    }
}
