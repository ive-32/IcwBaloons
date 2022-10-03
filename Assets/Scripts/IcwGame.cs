using UnityEngine;


namespace IcwBaloons
{
    internal class IcwGame : MonoBehaviour
    {
        [System.NonSerialized] public static int sizex = 3;
        [System.NonSerialized] public static int sizey = 12;

        public GameObject BadBoy;

        private void Start()
        {
            GameObject badboy = Instantiate(BadBoy);
            //badboy.transform.position = new Vector3(-1.0f, sizey - 1, 0);
        }
    }
}
