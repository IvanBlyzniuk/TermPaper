using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.InteractiveObjects.Actuators
{
    public class PressurePlate : BaseActuator
    {
        private int collisionCount;
        private SpriteRenderer spriteRenderer;
        private Sprite defaultSprite;
        private AudioSource audioSource;
        [SerializeField]
        private Sprite activeSprite;
        [SerializeField]
        private AudioClip activateSound;
        [SerializeField]
        private AudioClip deactivateSound;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultSprite = spriteRenderer.sprite;
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collisionCount == 0)
            {
                Activate();
                spriteRenderer.sprite = activeSprite;
                audioSource.PlayOneShot(activateSound);
            }
            collisionCount++;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collisionCount--;
            if(collisionCount <= 0)
            {
                Deactivate();
                spriteRenderer.sprite = defaultSprite;
                audioSource.PlayOneShot(deactivateSound);
            }
                
        }
    }
}
