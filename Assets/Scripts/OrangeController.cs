using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeController : MonoBehaviour
{
    Animator animator;
    bool animPlayed;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject == gameObject)
            {
                if (!animPlayed)
                {
                    animPlayed = true;
                    animator.Play("mouseOverOrange");
                    AudioManager.Instance.Play(gameObject.tag);
                }
            }
            else
                animPlayed = false;
    }
}
