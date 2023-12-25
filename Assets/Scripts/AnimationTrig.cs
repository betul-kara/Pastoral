using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrig : MonoBehaviour
{
    Animator animator;
    [SerializeField] float targetDistance, givenDistance = 50f;
    [SerializeField] GameObject outPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && PauseMenu.Instance.isPause == false)
        {

            RaycastHit hit;
            if (Physics.Raycast(outPoint.transform.position, outPoint.transform.TransformDirection(Vector3.back), out hit, givenDistance))
            {
                Debug.DrawRay(outPoint.transform.position, outPoint.transform.TransformDirection(Vector3.back) * givenDistance, Color.red);
                print(hit.collider.gameObject.name);
                targetDistance = hit.distance;

                if (targetDistance < givenDistance)
                {
                    animator.SetBool("trigger", true);
                    FireSpell.Instance.FireBullet(Vector3.back);

                    //StartCoroutine(DelayShoot(5));
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
    IEnumerator DelayShoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);


    }
}
