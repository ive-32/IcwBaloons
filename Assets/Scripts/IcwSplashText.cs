using UnityEngine;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;

namespace IcwBaloons
{
    public class IcwSplashText :MonoBehaviour
    {
        public static IcwSplashText instance;
        public GameObject splashTextprefab;
        TextMeshProUGUI tmplabel;
        TextMeshProUGUI tmpvalue;
        Animation anim;


        private void Awake()
        {
            
            instance = this;
        }

        public void SplashText(Vector3 pos, string avalue, string alabel = "", bool bckg = false)
        {
            GameObject pref = Instantiate(splashTextprefab, pos, Quaternion.identity, this.transform);

            GameObject canvas = pref.transform.Find("Canvas").gameObject;
            GameObject tmpChildObject;
            tmpChildObject = canvas.transform.Find("Value").gameObject;
            tmpvalue = tmpChildObject.GetComponent<TextMeshProUGUI>();
            tmpChildObject = canvas.transform.Find("Label").gameObject;
            tmplabel = tmpChildObject.GetComponent<TextMeshProUGUI>();
            anim = pref.GetComponent<Animation>();

            tmplabel.text = alabel;
            tmpvalue.text = avalue;
            float ttl = 0.3f;
            if (anim != null)
            {
                anim.Play();
                ttl = anim.clip.length;
            }
            tmpChildObject = pref.transform.Find("BackGroundBar").gameObject;
            tmpChildObject.SetActive(bckg);
            GameObject.Destroy(pref, ttl);
        }
    }
}
