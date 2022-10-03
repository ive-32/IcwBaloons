using UnityEngine;


namespace IcwBaloons
{
    public class IcwBaloon : MonoBehaviour
    {
        GameObject BaloonSprite;
        Rigidbody2D rg2d;
        float speed;
        Color balooncolor;

        

        private void Start()
        {
            speed = Random.Range(0.8f, 1.5f);
            balooncolor = IcwColors.GetRandomColor();
            BaloonSprite = this.transform.Find("Baloon").gameObject;
            BaloonSprite.GetComponent<SpriteRenderer>().color = balooncolor;
            rg2d = this.GetComponent<Rigidbody2D>();
            rg2d.velocity = Vector2.up * speed; //.AddForce(Vector2.up * speed, ForceMode2D.Force);

            GameObject gops = this.transform.Find("Particle System").gameObject;
            ParticleSystem ps = null;
            if (gops!=null) ps = gops.GetComponent<ParticleSystem>();
            if (ps!=null)
            {
                ParticleSystem.MainModule ma = ps.main;
                ma.startColor = balooncolor;
            }

        }

        private void Update()
        {
            if (Random.Range(0, 100) < 5)
            {
                // side move
                Vector2 currvel = rg2d.velocity;
                if (currvel.x == 0 && Random.Range(0, 100) < 10) currvel.x = Random.Range(-0.5f, 0.5f);
                else currvel.x = 0;
                rg2d.velocity = currvel;
            }
            if (this.transform.position.y > IcwGame.sizey) Object.Destroy(this.gameObject);    
        }

        private void OnMouseDown()
        {
            IcwBonusGenerator.Instance.gameObject.BroadcastMessage("BaloonWasBurst", balooncolor);
            Burst();
        }

        public void Burst()
        {
            Animation anim = this.GetComponent<Animation>();
            if (anim!=null)
            {
                anim.Play();
                Object.Destroy(this.gameObject, anim.clip.length);
            }
            else
                Object.Destroy(this.gameObject);
        }
    }
}
