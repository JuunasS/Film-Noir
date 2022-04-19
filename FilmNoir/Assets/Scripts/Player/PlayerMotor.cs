using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    NavMeshAgent agent;

    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();                           //pit‰‰ huolen ett‰ agentti osoittaa esineen suuntaan
        }

        if(agent.velocity.sqrMagnitude <= 1f)
        {
            animator.SetBool("isWalking", false);
        }
        if (agent.velocity.sqrMagnitude > 1f)
        {
            animator.SetBool("isWalking", true);
        }
    }

    public void MoveToPoint(Vector3 point)
    {

        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)        //kutsutaan kun napautetaan interactable objectia, ja k‰vell‰‰n sen luo
    {
        agent.stoppingDistance = newTarget.radius * .8f;    //et‰isyys jolla agentti lopettaa liikkumisen (jotta ei mene interactablen sis‰‰n
        agent.updateRotation = false;
        target = newTarget.GetLocation();
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;                          //get direction towards target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0001f, direction.z));   //find how to rotate ourself to look in the direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);   // rotate
    }
}

