using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        private Rigidbody2D heldObject;
        private List<GameObject> objectsToInterract = new List<GameObject>();

        [SerializeField]
        private Transform heldObjectAnchor;

        public void Interract()
        {
            if (heldObject == null)
            {
                if (objectsToInterract.Count == 0)
                    return;
                GameObject objectToInterract = objectsToInterract[objectsToInterract.Count - 1];
                //objectToInterract.layer == LayerMask.NameToLayer
                //if(objectToInterract.GetComponent<InteractiveObject>() != null)
                {
                    heldObject = objectToInterract.GetComponent<Rigidbody2D>();
                    heldObject.gravityScale = 0;
                    heldObject.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
            else
            {
                heldObject.gravityScale = 1;
                heldObject.constraints = RigidbodyConstraints2D.None;
                heldObject = null;
            }
        }

        void Update()
        {
            if (heldObject == null)
                return;
            //give speed and angular speed proportional to distance to correct pos
            heldObject.transform.position = Vector2.Lerp(heldObject.transform.position, heldObjectAnchor.transform.position, 0.3f);
            //heldObject.transform.up = Vector2.Lerp(heldObject.transform.up, Vector2.up, 0.3f);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            objectsToInterract.Add(collision.gameObject);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            objectsToInterract.Remove(collision.gameObject);
        }
    }
}
