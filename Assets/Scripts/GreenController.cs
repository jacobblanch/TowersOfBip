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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject == myGameObject)
            {
                if (!animPlayed)
                {
                    animPlayed = true;
                    animator.Play("mouseOver");
                    if (gameObject.CompareTag("1"))
                        AudioManager.Instance.Play("ding1");
                    else if (gameObject.CompareTag("2"))
                        AudioManager.Instance.Play("ding2");
                    else if (gameObject.CompareTag("3"))
                        AudioManager.Instance.Play("ding3");
                    else if (gameObject.CompareTag("4"))
                        AudioManager.Instance.Play("ding4");                   
                }
            }
            else
                animPlayed = false;
	}
}
