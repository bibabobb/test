using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerItems : MonoBehaviour
{
    public float distance = 2f;
    // Start is called before the first frame update
    // public ve handPoint= transform.position.x+0.3;
    public Transform handPoint;
    public bool handBusy;
    RaycastHit2D interactiveItem;

    GameObject equipedItem;
    void Start()
    {

        handPoint = transform.GetChild(0);
        handPoint.localPosition = new Vector2(0.3f,0f);
        // hand.transform.parent = 
        handBusy = false;

        // Transform handt = transform.GetChild(0);
        // Debug.Log(handt.name);
        // handPoint = 
        // Debug.Log(handPoint.name);
        // handPoint.localPosition = new Vector3(0.3f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        getItem();
    }

    void getItem(){
        bool interactiveItemExist = false;
        if (Input.GetKeyDown(KeyCode.E)){
            Debug.Log("use");
            Physics2D.queriesStartInColliders = false;
            interactiveItem = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

            if (interactiveItem.collider != null && interactiveItem.collider.gameObject.GetComponent<Rigidbody2D>() != null){
                Debug.Log(interactiveItem.collider.gameObject.name);
                interactiveItemExist = true;
            }
        }
        if (interactiveItemExist){
            equipedItem = interactiveItem.collider.gameObject;
            equipedItem.transform.parent = handPoint;
            // equipedItem.transform.position = handPoint.position;
            FixedJoint2D joint2D = equipedItem.GetComponent<FixedJoint2D>();
            

            joint2D.anchor = handPoint.position;
            joint2D.connectedBody = transform.GetComponent<Rigidbody2D>();
            interactiveItem.collider.enabled = false;
            joint2D.connectedAnchor += Vector2.up *1;
            // equipedItem.GetComponent<FixedJoint2D>().connectedBody = transform.GetComponent<Rigidbody2D>();

            // interactiveItem.collider.transform.parent = handPoint;
            // interactiveItem.collider.transform.localPosition = new Vector2(0, 0.2f);
            // interactiveItem.collider.transform.localRotation = Quaternion.Euler(0,0,-20f);
            
            handBusy = true;
            // equipedItem = interactiveItem.collider.gameObject;
            // item.collider.gameObject.GetComponent<Rigidbody2D>()
            // item.collider.gameObject.transform.localPosition = new Vector2(handPoint.x,handPoint.y+2);
        }
        if (handBusy && handPoint.position.x < transform.position.x){
            // equipedItem.transform.localScale = transform.position.x
            // handPoint.localScale = 
        }
    }

    void dropItem(){
        if (Input.GetKeyDown(KeyCode.G)){
            Debug.Log("try drop");

        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, Vector3.right * transform.localScale.x * distance);
    }
}
