using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enamy : MonoBehaviour
{
    [SerializeField] Material deathMat;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] Animator animator;
    [SerializeField] Main main;
    [SerializeField] Controller controller;
    private Transform player;
    private Rigidbody rigidbody;
    private NavMeshAgent navMeshAgent;
    private bool attack = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {


        if (attack)
        {
            navMeshAgent.destination = player.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) < 6)
            {
                attack = true;
                animator.SetBool("run", true);
                navMeshAgent.enabled = true;
                rigidbody.isKinematic = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {

            controller.OffParticle();
            main.Lose();
            Destroy(gameObject);
        }
    }

    public void Death()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        navMeshAgent.enabled = false;
        skinnedMeshRenderer.material = deathMat;
        animator.SetBool("run", false);
        Destroy(gameObject.GetComponent<Enamy>());
    }
}
