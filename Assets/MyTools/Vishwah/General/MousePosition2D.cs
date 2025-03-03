using UnityEngine;

namespace Vishwah.General
{
    public class MousePosition2D : MonoBehaviour
    {
        private Camera MainCamera;

        private void Awake()
        {
            MainCamera = Camera.main;
        }

        public Vector3 MousePosition()
        {
            Vector3 mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            return mousePos;
        }
    }
}

