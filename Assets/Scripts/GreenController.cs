using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenController : MonoBehaviour {
    public Vector3 UltimatePosition = new Vector3(0, 0, 0);
    GameObject myGameObject;
    Animator animator;
    bool animPlayed;
    float X, Y;

    // Use this for initialization
    void Start () {
        myGameObject = this.gameObject;
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        X = Input.mousePosition.x;
        Y = Input.mousePosition.y;
        Vector3 mouselocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject == myGameObject)
            {
                /*Vector3 pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                transform.position = Camera.main.ScreenToWorldPoint(pos);*/
                if (!animPlayed)
                {
                    animPlayed = true;
                    animator.Play("mouseOver");
                    if (gameObject.CompareTag("1"))
                        FindObjectOfType<AudioManager>().Play("ding1");
                    else if (gameObject.CompareTag("2"))
                        FindObjectOfType<AudioManager>().Play("ding2");
                    else if (gameObject.CompareTag("3"))
                        FindObjectOfType<AudioManager>().Play("ding3");
                    else if (gameObject.CompareTag("4"))
                        FindObjectOfType<AudioManager>().Play("ding4");
                }
            }
            else
                animPlayed = false;
	}
}
