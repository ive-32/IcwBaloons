
using UnityEngine;

namespace IcwBaloons
{
    public class IcwLantern : IcwBaseHelper
    {

        public override void Start()
        {
            base.Start();
            Animation appear = this.GetComponent<Animation>();
            appear.Play();
        }

        
        void OnTriggerEnter2D(Collider2D other)
        {
            IcwBaseBaloon bl = other.attachedRigidbody.gameObject.GetComponent<IcwBaseBaloon>();
            if (bl != null) bl.Burst();
        }
    }
}
