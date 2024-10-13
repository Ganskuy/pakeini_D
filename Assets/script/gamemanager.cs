using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleController : MonoBehaviour
{
    private string playerResult;
    private string enemyResult;
    private bool playerReady = false;
    private bool enemyReady = false;
    private bool playerFinished = false;
    private bool enemyFinished = false;

    public PlayerRoulette playerRoulette;
    public EnemyRoulette enemyRoulette;
    public Player player;
    public Enemy enemy;

    public void SetPlayerResult(string result)
    {
        playerResult = result;
        playerReady = true;
        Debug.Log("Player result set: " + playerResult);
    }

    public void SetEnemyResult(string result)
    {
        enemyResult = result;
        enemyReady = true;
        Debug.Log("Enemy result set: " + enemyResult);
    }

    public void OnPlayerRouletteFinished()
    {
        playerFinished = true;
        Debug.Log("Player roulette finished spinning. playerReady: " + playerReady + " enemyReady: " + enemyReady);
        TryCheckBattleOutcome();
    }

    public void OnEnemyRouletteFinished()
    {
        enemyFinished = true;
        Debug.Log("Enemy roulette finished spinning. playerReady: " + playerReady + " enemyReady: " + enemyReady);
        TryCheckBattleOutcome();
    }

    private void TryCheckBattleOutcome()
    {
        Debug.Log("TryCheckBattleOutcome called. playerFinished: " + playerFinished + ", enemyFinished: " + enemyFinished + 
                  ", playerReady: " + playerReady + ", enemyReady: " + enemyReady);

        if (playerFinished && enemyFinished && playerReady && enemyReady)
        {
            Debug.Log("Both roulettes finished. Checking battle outcome...");
            playerFinished = false;
            enemyFinished = false;
            CheckBattleOutcome();
        }
        else
        {
            Debug.Log("Waiting for both roulettes to finish...");
        }
    }

    private void CheckBattleOutcome()
    {
        Debug.Log("Battle result - Player: " + playerResult + ", Enemy: " + enemyResult);

        if ((playerResult == "paper" && enemyResult == "rock") ||
            (playerResult == "rock" && enemyResult == "scissors") ||
            (playerResult == "scissors" && enemyResult == "paper"))
        {
            player.Attack();
            Debug.Log("Player attacks enemy!");
        }
        else if ((enemyResult == "paper" && playerResult == "rock") ||
                 (enemyResult == "rock" && playerResult == "scissors") ||
                 (enemyResult == "scissors" && playerResult == "paper"))
        {
            enemy.Attack();
            Debug.Log("Enemy attacks player!");
        }
        else
        {
            Debug.Log("It's a tie! No one attacks.");
        }

        // Reset readiness for the next spin
        playerReady = false;
        enemyReady = false;
    }
}