using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Animator anim;

    private Vector3 offset;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        offset = transform.position - player.transform.position;

        if (Mathf.Abs(offset.magnitude) > 4)
        {
            anim.SetBool("Bark_b", false);
            agent.SetDestination(player.transform.position);      
        }
        else
        {
            agent.ResetPath();
            anim.SetBool("Bark_b", true);
            print("Hasar Verildi!");
        }

        if (agent.velocity == Vector3.zero)
        {
            anim.SetFloat("Speed_f", 0f,0.6f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed_f", 1f,0.6f, Time.deltaTime);
        }

    }
}
