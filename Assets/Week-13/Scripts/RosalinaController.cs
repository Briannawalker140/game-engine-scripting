using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosalinaController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    [ContextMenu("Do Walk")]
    void DoWalk()
    {
        animator.SetInteger("speed", 3);
    }

    [ContextMenu("Do Run")]
    void DoRun()
    {
        animator.SetInteger("speed", 8);
    }

    [ContextMenu("Do Idle")]
    void DoIdle()
    {
        animator.SetInteger("speed", 0);
    }

    [ContextMenu("Do Jump")]
    void DoJump()
    {
        animator.SetInteger("speed", 10);
    }


}
