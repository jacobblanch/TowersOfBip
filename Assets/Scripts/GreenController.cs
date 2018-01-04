using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenController : MonoBehaviour 
{
    GameObject myGameObject;
    Animator animator;
    bool animPlayed;
    public GameObject closestOrange;
    Vector3 offset = new Vector3(0, 0, -1);
    bool locked;

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject == gameObject)
            {
                if (!animPlayed)
                {
                    animPlayed = true;
                    animator.Play("mouseOver");
                    AudioManager.Instance.Play(gameObject.tag);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    //if greendude is locked, unlock him and set his pos to the empty space
                    if (locked)
                    {                        
                        transform.position = closestOrange.transform.position + offset;
                        locked = false;
                    }
                    //else lock him to mouse cursor
                    else
                        locked = true;
                }
            }
            else
                animPlayed = false;

        //if the greendude is set to be locked to the mouse cursor then lockhim to the mouse cursor and check for the closest orange space while he is locked
        if (locked)
        {
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            closestOrange = GameManager.Instance.CheckDistance(gameObject);
        }
    }
}
