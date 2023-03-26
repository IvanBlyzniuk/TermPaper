using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects.Activables
{
    public class TestActivatable : BaseActivable
    {
        [SerializeField]
        private Sprite baseSprite;
        [SerializeField]
        private Sprite activeSprite;

        protected override void OnActivate()
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }

        protected override void OnDeactivate()
        {
            GetComponent<SpriteRenderer>().sprite = baseSprite;
        }
    }
}
