using UnityEngine;

public class PlayerRoulette : MonoBehaviour
{
    public int rotatePower = 300; // Lowered rotate power to make it easier to stop
    public int stopPower = 1000;  // Increased stop power for quicker deceleration
    private Rigidbody2D rbody;
    private bool isSpinning;
    private const float spinStopThreshold = 0.01f; // Lowered threshold for more precise stopping
    public string playerResult;

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
            Debug.Log("Player - Current Angular Velocity: " + rbody.angularVelocity); // Added debugging output

            // Gradually reduce the angular velocity toward 0
            rbody.angularVelocity = Mathf.MoveTowards(rbody.angularVelocity, 0, stopPower * Time.deltaTime);

            // Check if the spin is slow enough to be considered stopped
            if (Mathf.Abs(rbody.angularVelocity) <= spinStopThreshold)
            {
                Debug.Log("Player roulette stopping. Angular velocity: " + rbody.angularVelocity); // Debug log for stopping condition
                
                rbody.angularVelocity = 0; // Ensure it fully stops
                isSpinning = false;
                GetPlayerResult();
                battleController.OnPlayerRouletteFinished();
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
            Debug.Log("Player roulette started spinning with torque: " + rotatePower);
        }
    }

    private void GetPlayerResult()
    {
        float rot = transform.eulerAngles.z;

        if (rot >= 0 && rot < 120)
        {
            playerResult = "paper";
        }
        else if (rot >= 120 && rot < 240)
        {
            playerResult = "scissors";
        }
        else if (rot >= 240 && rot <= 360)
        {
            playerResult = "rock";
        }

        Debug.Log("Player chose: " + playerResult);
        battleController.SetPlayerResult(playerResult);
    }
}