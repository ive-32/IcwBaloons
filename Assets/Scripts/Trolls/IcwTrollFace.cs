using Unity.VisualScripting;
using UnityEngine;


namespace IcwBaloons
{
    public class IcwTrollFace : MonoBehaviour
    {
        public GameObject baloonprefab;
        GameObject baloon;
        Color balooncolor;
        float ttl;
        Animation anim;

        private void Awake()
        {
            baloon = this.transform.Find("Baloon").gameObject;
            SpriteRenderer sr = baloon.GetComponent<SpriteRenderer>();
            balooncolor = IcwColors.GetRandomColor();
            sr.color = balooncolor;
            ttl = Random.Range(3, 15);
            anim = this.GetComponent<Animation>();
        }

        private void Update()
        {
            ttl -= Time.deltaTime;
            if (ttl <= 0 )
            {
                ttl = 100000;
                GameObject newbaloon = Instantiate(baloonprefab);
                IcwBaloon baloonclass = newbaloon.GetComponent<IcwBaloon>();
                baloonclass.SetColor(balooncolor);
                baloonclass.SetSpeed(4.5f);
                newbaloon.transform.position = baloon.transform.position;

                baloon.SetActive(false);
                float animlenght = 0.0f;
                if (anim != null )
                {
                    AnimationClip clip = anim.GetClip("TrollDestroyAnimation");
                    if (clip != null)
                    {
                        anim.Play("TrollDestroyAnimation");
                        animlenght = clip.length;
                    }
                }
                Destroy(this.gameObject, animlenght);
            }
        }
    }
}
