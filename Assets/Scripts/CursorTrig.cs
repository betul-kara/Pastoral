using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrig : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Hedefler;

    private void Start()
    {
        foreach (var hedefler in Hedefler)
        {
            hedefler.GetComponent<Animator>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (GameObject hedef in Hedefler)
            {
                hedef.GetComponent<Animator>().enabled = true;
            }
            StartCoroutine(Bekleme());
        }
    }
    IEnumerator Bekleme()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject hedefler in Hedefler)
        {
            hedefler.GetComponent<Animator>().enabled = false;
        }
    }
}
