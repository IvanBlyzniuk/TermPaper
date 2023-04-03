using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        private Rigidbody2D heldObject;
        private TargetJoint2D heldObjectTarget;
        private Collider2D heldObjectCollider;
        private List<GameObject> objectsToInterract = new List<GameObject>();
        private Coroutine turningCoroutine;
        private AudioSource audioSource;
        

        [SerializeField]
        private Collider2D myCollider;
        [SerializeField]
        private Transform heldObjectAnchor;
        [SerializeField]
        private AudioClip interactSound;

        private void Awake()
        {
            audioSource = GetComponentInParent<AudioSource>();
        }

        public void Interract()
        {
            if (!TryDropObject())
            {
                if (objectsToInterract.Count == 0)
                    return;
                GameObject objectToInterract = objectsToInterract[objectsToInterract.Count - 1];
                heldObject = objectToInterract.GetComponent<Rigidbody2D>();
                heldObjectTarget = objectToInterract.GetComponent<TargetJoint2D>();
                heldObjectCollider = objectToInterract.GetComponent<Collider2D>();
                heldObjectTarget.enabled = true;
                heldObjectTarget.target = heldObjectAnchor.position;
                heldObject.constraints = RigidbodyConstraints2D.FreezeRotation;
                audioSource.PlayOneShot(interactSound);
            }
        }

        public bool TryDropObject()
        {
            if (heldObject == null)
                return false;
            heldObjectTarget.enabled = false;
            heldObject.constraints = RigidbodyConstraints2D.None;
            heldObject = null;
            return true;
        }

        public void TurnAround()
        {
            if (heldObject == null)
                return;
            Physics2D.IgnoreCollision(myCollider,heldObjectCollider);
            if(turningCoroutine != null)
                StopCoroutine(turningCoroutine);
            turningCoroutine = StartCoroutine(ReactivateCollisions(0.1f,heldObjectCollider));
        }

        private IEnumerator ReactivateCollisions(float delay, Collider2D collider)
        {
            yield return new WaitForSeconds(delay);
            Physics2D.IgnoreCollision(myCollider, collider,false);
        }

        void Update()
        {
            if (heldObject == null)
                return;
            heldObjectTarget.target = heldObjectAnchor.position;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.enabled)
                return;
            objectsToInterract.Add(collision.gameObject);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            objectsToInterract.Remove(collision.gameObject);
        }
    }
}
