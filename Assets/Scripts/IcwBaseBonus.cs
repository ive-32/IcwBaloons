using UnityEngine;

namespace IcwBaloons
{
    public class IcwBaseBonus : MonoBehaviour
    {
        protected float ttldefault = 30;
        protected float ttl;
        protected IcwSatusBar ttlBar;

        public virtual void Start()
        {
            ttl = ttldefault;
            ttlBar = this.transform.Find("IcwStatusBar").gameObject.GetComponent<IcwSatusBar>();
        }

        public virtual void Update()
        {
            ttl -= Time.deltaTime;
            ttlBar.SetStatusBar(ttl / ttldefault);
            if (ttl <= 0) Destroy(this.gameObject);
        }
    }
}
