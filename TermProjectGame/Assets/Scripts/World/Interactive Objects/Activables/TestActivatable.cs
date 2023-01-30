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

        public override void Activate()
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }

        public override void Deactivate()
        {
            GetComponent<SpriteRenderer>().sprite = baseSprite;
        }
    }
}
