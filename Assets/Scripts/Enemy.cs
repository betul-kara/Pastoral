using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    Animator animator;


    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }


}
