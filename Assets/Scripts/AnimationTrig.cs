using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrig : MonoBehaviour
{
    Animator animator;
    [SerializeField] float targetDistance, givenDistance = 30f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, givenDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * givenDistance, Color.red);
                targetDistance = hit.distance;

                if (targetDistance < givenDistance)
                {
                    animator.SetBool("trigger", true);
                    FireSpell.Instance.FireBullet(Vector3.back);


                    //AudioSource spellSound = GetComponent<AudioSource>();
                    //spellSound.Play();

                }
            }

        }
        else
        {
            animator.SetBool("trigger", false);
        }
    }
}
