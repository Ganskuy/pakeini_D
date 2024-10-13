using UnityEngine;

public class tbmcanimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        // Trigger the attack animation
        animator.SetTrigger("Attack");
    }

    // This method can be called from an Animation Event at the end of the Attack animation
    public void EndAttack()
    {
        // Optionally, set the idle state or trigger
        animator.SetTrigger("Idle"); // If you have an Idle trigger
    }
}
