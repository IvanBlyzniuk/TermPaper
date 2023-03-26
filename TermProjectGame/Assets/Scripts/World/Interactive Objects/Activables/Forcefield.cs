using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects.Activables
{
    public class Forcefield : BaseActivable
    {
        [SerializeField]
        private float animationTime;
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private BoxCollider2D myCollider;
        protected override void OnActivate()
        {
            myCollider.enabled = false;
            StopAllCoroutines();
            StartCoroutine(makeSpriteTransparent());
        }

        protected override void OnDeactivate()
        {
            myCollider.enabled = true;
            StopAllCoroutines();
            StartCoroutine(makeSpriteNonTransparent());
        }

        private IEnumerator makeSpriteTransparent()
        {
            float alpha = spriteRenderer.color.a;
            while (alpha > 0f)
            {
                spriteRenderer.color = new Color(1f,1f,1f,alpha - Time.deltaTime/animationTime);
                alpha = spriteRenderer.color.a;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        private IEnumerator makeSpriteNonTransparent()
        {
            float alpha = spriteRenderer.color.a;
            while (alpha < 1f)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, alpha + Time.deltaTime / animationTime);
                alpha = spriteRenderer.color.a;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
