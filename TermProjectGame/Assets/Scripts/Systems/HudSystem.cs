using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using World.HUD;

namespace Systems
{
    public class HudSystem : MonoBehaviour
    {
        private Image blackOverlay;
        private PauseHandler pauseScreen;
        private TextMeshProUGUI cloneCountText;

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

        public void Init(Image blackOverlay, PauseHandler pauseScreen, TextMeshProUGUI cloneCountText)
        {
            this.blackOverlay = blackOverlay;
            this.pauseScreen = pauseScreen;
            this.cloneCountText = cloneCountText;
        }

        public void Pause()
        {
            pauseScreen.Pause();
        }

        public void updateCloneCount(int count)
        {
            cloneCountText.text = $"x {count}";
        }
    }
}
