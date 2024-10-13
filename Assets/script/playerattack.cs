using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform firepoint;
    public GameObject batuprefab;
    public bool isAttacking = false;

    // Reference to the playertb component assigned through the Inspector
    public playertb playerController; 

    public void Attack()
    {
        Instantiate(batuprefab, firepoint.position, firepoint.rotation);
        isAttacking = true;

        // Check if playerController is not null before calling the method
        if (playerController != null)
        {
            playerController.Attackanim();
        }
        else
        {
            Debug.LogError("playerController is null. Cannot call Attackanim()");
        }

        // Start the coroutine to end the attack and transition to idle
        StartCoroutine(EndAttack());
    }

    private IEnumerator EndAttack()
    {
        // Wait for the duration of the attack animation (adjust as needed)
        yield return new WaitForSeconds(0.1f); // Adjust this value based on your attack animation length

        isAttacking = false;

        // Trigger the idle animation in playertb
        if (playerController != null)
        {
            playerController.EndAttackanim();
        }
    }
}