using UnityEngine;

public class EnemyRoulette : MonoBehaviour
{
    public int rotatePower = 300; // Lowered rotate power to see if stopping works better
    public int stopPower = 1000; // Further increased stop power for quicker deceleration
    private Rigidbody2D rbody;
    private bool isSpinning;
    private const float spinStopThreshold = 0.01f; // Lowered threshold for stopping
    public string enemyResult;

    public BattleController battleController;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        isSpinning = false;
    }

    private void Update()
    {
        if (isSpinning)
        {
            Debug.Log("Current Angular Velocity: " + rbody.angularVelocity); // Added debugging output
            
            // Gradually reduce the angular velocity toward 0
            rbody.angularVelocity = Mathf.MoveTowards(rbody.angularVelocity, 0, stopPower * Time.deltaTime);

            // Check if the spin is slow enough to be considered stopped
            if (Mathf.Abs(rbody.angularVelocity) <= spinStopThreshold) 
            {
                Debug.Log("Roulette stopping. Angular velocity: " + rbody.angularVelocity); // Debug log for stopping condition
                
                rbody.angularVelocity = 0; // Ensure it fully stops
                isSpinning = false;
                GetEnemyResult();
                battleController.OnEnemyRouletteFinished();
            }
        }
    }

    public void Rotate()
    {
        if (!isSpinning)
        {
            rbody.angularVelocity = 0; // Ensure no residual velocity
            rbody.AddTorque(rotatePower, ForceMode2D.Impulse); // Apply torque to start spinning
            isSpinning = true;
            Debug.Log("Enemy roulette started spinning with torque: " + rotatePower);
        }
    }

    private void GetEnemyResult()
    {
        float rot = transform.eulerAngles.z;

        if (rot >= 0 && rot < 120)
        {
            enemyResult = "paper";
        }
        else if (rot >= 120 && rot < 240)
        {
            enemyResult = "scissors";
        }
        else if (rot >= 240 && rot <= 360)
        {
            enemyResult = "rock";
        }

        Debug.Log("Enemy chose: " + enemyResult);
        battleController.SetEnemyResult(enemyResult);
    }
}