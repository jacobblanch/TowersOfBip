using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenController : MonoBehaviour 
{
    Animator animator;

    public bool animPlayed;

    public GameObject closestOrange;

    Vector3 offset = new Vector3(0, 0, -1);

    public bool locked;

    bool selected;

    public List<GameObject> greens = new List<GameObject>();

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
        GameObject[] objs = FindObjectsOfType<GameObject>();
        foreach(GameObject obj in objs)
        {
            if (obj.GetComponent<GreenController>() != null)
            {
                greens.Add(obj);
            }
        }
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
                    if (!selected)
                        if (Physics.Raycast(ray, out hit))
                            if (hit.collider.gameObject == gameObject)
                             selected = true;
                    //if greendude is locked, unlock him and set his pos to the empty space
                    if (locked)
                    {                        
                        //transform.position = closestOrange.transform.position + offset;
                        for (int i = 0; i < greens.Count; i++)
                        {
                            greens[i].GetComponent<GreenController>().locked = false;
                        }
                    }
                    //else lock him to mouse cursor
                    else
                    {
                        for (int i = 0; i < greens.Count; i++)
                        {
                            greens[i].GetComponent<GreenController>().locked = true;
                            greens[i].GetComponent<GreenController>().animPlayed = true;
                        }
                        AudioManager.Instance.Play("Pickup");
                    }
                } else if (Input.GetMouseButtonUp(0))
                {
                    if (selected)
                    {
                        selected = false;
                        for (int i = 0; i < greens.Count; i++)
                            greens[i].GetComponent<GreenController>().animPlayed = false;
                    }
                }
            } else if (!locked)
                animPlayed = false;

        //if the greendude is set to be locked to the mouse cursor then lockhim to the mouse cursor and check for the closest orange space while he is locked
        if (selected)
        {
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            closestOrange = GameManager.Instance.CheckDistance(gameObject);
        } else
        {
            transform.position = closestOrange.transform.position + offset;
        }
    }
}
