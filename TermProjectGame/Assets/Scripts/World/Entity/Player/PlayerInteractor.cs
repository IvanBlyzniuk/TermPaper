using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        private Rigidbody2D heldObject;
        private List<GameObject> objectsToInterract = new List<GameObject>();
        private TargetJoint2D heldObjectTarget;

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
                    heldObjectTarget = objectToInterract.GetComponent<TargetJoint2D>();
                    heldObjectTarget.enabled = true;
                    //heldObject.gravityScale = 0;
                    //heldObject.constraints = RigidbodyConstraints2D.FreezeRotation;
                    //heldObject.drag = 10;

                    //heldObject.transform.parent = heldObjectAnchor;

                }
                //else
                //{
                //    button.Interract();
                //}
            }
            else
            {
                //heldObject.gravityScale = 1;
                //heldObject.drag = 1;
                //heldObject.constraints = RigidbodyConstraints2D.None;
                //heldObject.transform.parent = null;
                heldObjectTarget.enabled = false;
                heldObject = null;
            }
        }

        void Update()
        {
            if (heldObject == null)
                return;
            heldObjectTarget.target = heldObjectAnchor.position;
            //if (Vector2.Distance(heldObject.transform.position, heldObjectAnchor.position) > 0.1f)
            //{
            //    Vector2 moveDirection = heldObjectAnchor.position - heldObject.transform.position;
            //    heldObject.AddForce(moveDirection * 15);
            //}
            //give speed and angular speed proportional to distance to correct pos
            //heldObject.transform.position = Vector2.Lerp(heldObject.transform.position, heldObjectAnchor.transform.position, 0.3f);
            //heldObject.transform.up = Vector2.Lerp(heldObject.transform.up, Vector2.up, 0.3f);
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
