using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IcwBaloons
{

    public class IcwCamera : MonoBehaviour
    {
        [System.NonSerialized] public ScreenOrientation currentorientation;
        [System.NonSerialized] public static Camera maincamera;


        private void Awake()
        {
            maincamera = this.GetComponent<Camera>();
        }

        void Start()
        {
            currentorientation = Screen.orientation;
            SetUpCameraAngle();
            SetUpCameraPosition();
        }

        void SetUpCameraAngle()
        {
            if (maincamera == null) return;
            float fCameraAspect;
            float fCameraSize;
            float minscreeensize = Mathf.Min(maincamera.pixelWidth, maincamera.pixelHeight);
            float maxscreeensize = Mathf.Max(maincamera.pixelWidth, maincamera.pixelHeight);
            fCameraAspect = minscreeensize / maxscreeensize;
            float minsize = Mathf.Min(IcwGame.sizex, IcwGame.sizey) + 0.5f;
            float maxsize = Mathf.Max(IcwGame.sizex, IcwGame.sizey) + 0.5f;

            /*if (maincamera.pixelWidth > maincamera.pixelHeight)
            {
                if (fCameraAspect < minsize  / maxsize ) { fCameraSize = maxsize * fCameraAspect; }
                else { fCameraSize = minsize; }
            }
            else*/
            {
                if (fCameraAspect < minsize / maxsize ) { fCameraSize = minsize / fCameraAspect; }
                else { fCameraSize = maxsize; }
            }

            maincamera.orthographicSize = fCameraSize / 2;

        }
        void SetUpCameraPosition()
        {
            float maxsize = Mathf.Max(IcwGame.sizex, IcwGame.sizey);
            float minsize = Mathf.Min(IcwGame.sizex, IcwGame.sizey);
            /*if (maincamera.pixelWidth > maincamera.pixelHeight)
                this.transform.localPosition = new Vector3(maxsize / 2.0f, minsize / 2.0f, -50);
            else*/
                
                this.transform.localPosition = new Vector3(minsize / 2.0f, maxsize / 2.0f, -50);
        }


        private void Update()
        {


            if (Screen.orientation != currentorientation)
            {

                SetUpCameraAngle();
                SetUpCameraPosition();

                currentorientation = Screen.orientation;
            }
        }
    }
}
