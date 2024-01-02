using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrig : MonoBehaviour
{
    Animator animator;
    [SerializeField] float targetDistance, givenDistance = 50f;
    [SerializeField] GameObject outPoint;
    public bool hasFired = false;
    float currentCooldown = 0f;
    float attackCooldown = 5f;
    [SerializeField] AudioSource spellSound;


    private void Start()
    {
        animator = GetComponent<Animator>();
        spellSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && PauseMenu.Instance.isPause == false)
        {

            RaycastHit hit;
            if (Physics.Raycast(outPoint.transform.position, outPoint.transform.TransformDirection(Vector3.back), out hit, givenDistance))
            {
                targetDistance = hit.distance;

                if (targetDistance < givenDistance)
                {
                    animator.SetBool("trigger", true);
                    FireSpell.Instance.FireBullet(Vector3.back);


                    spellSound.Play();
                }
            }

        }
        else
        {
            animator.SetBool("trigger", false);
        }
    }

}
