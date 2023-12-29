using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public static Wolf Instance;
    Transform target;
    Animator animator;
    public float moveSpeed = 1f;
    public float attackRange = 1.5f;
    public float detectRange = 10f;
    [SerializeField] int damageAmount = 5;
    [SerializeField] int enemyHealth;
    public bool isDied = false;
    bool isAttacking = false;
    bool isChasing = false;
    float attackCooldown = 1.5f;
    float currentCooldown = 0f;
    public bool isDamaged = false;

    private void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>(); // burası farklı
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (!isDied)
        {
            Movement();
        }
    }

    private void Movement()
    {

        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= attackRange)
            {
                Attack();
            }
            else if (distanceToTarget <= detectRange)
            {
                MoveTowardsTarget();
                isChasing = true;
            }
            else
            {
                isChasing = false;
                animator.SetBool("Running", false);
                animator.SetBool("Attacking", false);
            }
        }
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            isAttacking = false;
        }

    }

    public void Attack()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Attacking", true);

        if (!isAttacking && Player.Instance.health > 0)
        {
            isAttacking = true;
            Player.Instance.TakeDamage(5);
            currentCooldown = attackCooldown;

            if (Player.Instance.health > 0)
            {
                // flash
            }
        }
    }
    public void MoveTowardsTarget()
    {
        if (!isDamaged)
        {
            transform.LookAt(target.position);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            animator.SetBool("Running", true);
            animator.SetBool("Attacking", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            if (!isDied)
            {
                StartCoroutine(Damage());

                EnemyHealth(damageAmount);

            }
        }

    }
    IEnumerator Damage()
    {
        isDamaged = true;
        animator.SetTrigger("damage");
        yield return new WaitForSeconds(1.3f);
        isDamaged = false;
    }
    public void EnemyHealth(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            isDied = true;
            animator.SetTrigger("Die");
            //gameObject.SetActive(false);
            Destroy(gameObject, 3);
            // takip etmesi güzel mi??
        }
    }
}

// güvenli alana geldiginde koyunlar serbest gezinsin