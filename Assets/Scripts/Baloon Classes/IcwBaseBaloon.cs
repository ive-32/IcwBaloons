using UnityEngine;


namespace IcwBaloons
{
    public class IcwBaseBaloon : MonoBehaviour
    {
        protected Rigidbody2D rg2d;
        protected float speed = 1.0f;
        protected Color balooncolor;


        
        protected virtual void SetBurstColor(Color acolor)
        {
            GameObject gameObjectParticleSystem = this.transform.Find("Particle System").gameObject;
            ParticleSystem partileSystem = null;
            if (gameObjectParticleSystem != null)
                partileSystem = gameObjectParticleSystem.GetComponent<ParticleSystem>();
            if (partileSystem != null)
            {
                ParticleSystem.MainModule mainModule = partileSystem.main;
                mainModule.startColor = acolor;
            }
        }

        public virtual void SetSpeed(float aspeed)
        {
            speed = aspeed;
            rg2d.velocity = Vector2.up * speed * IcwGame.gameBaseSpeed;
        }

        protected virtual void Awake()
        {
            rg2d = this.GetComponent<Rigidbody2D>();
            SetSpeed(speed);
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            if (Random.Range(0, 100) < 5 && rg2d!= null)
            {
                // side move
                Vector2 currvel = rg2d.velocity;
                if (currvel.x == 0 && Random.Range(0, 100) < 10) currvel.x = Random.Range(-0.5f, 0.5f);
                else currvel.x = 0;
                rg2d.velocity = currvel;
            }
            if (this.transform.position.y > IcwGame.sizey)
            {
                Object.Destroy(this.gameObject);
                IcwGame.instance.lostballs++;
                IcwLostBalls.instance.ShowLostBalls();
            }
        }

        protected virtual void OnMouseDown()
        {
            Burst();
        }

        public virtual void Burst()
        {
            Animation anim = this.GetComponent<Animation>();
            if (anim != null)
            {
                anim.Play();
                Object.Destroy(this.gameObject, anim.clip.length);
            }
            else
                Object.Destroy(this.gameObject);
        }
    }
}
