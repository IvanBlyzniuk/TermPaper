using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class HudSystem : MonoBehaviour
    {
        private Image blackOverlay;

        public float BlackOverlayAlpha
        {
            get
            {
                return blackOverlay.color.a;
            }
            set
            {
                blackOverlay.color = new Color(0, 0, 0, value);
            }
        }

        public void Init(Image blackOverlay)
        {
            this.blackOverlay = blackOverlay;
        }

    }
}
