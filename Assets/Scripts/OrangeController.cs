using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeController : MonoBehaviour
{
    GameObject myGameObject;
    Animator animator;
    bool animPlayed;

    // Use this for initialization
    void Start()
    {
        myGameObject = this.gameObject;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject == myGameObject)
            {
                if (!animPlayed)
                {
                    animPlayed = true;
                    animator.Play("mouseOverOrange");
                    AudioManager.Instance.Play(myGameObject.tag);
                }
            }
            else
                animPlayed = false;
    }
}
