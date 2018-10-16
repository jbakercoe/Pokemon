using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    [SerializeField]
    BattlePokemon playerPokemon;
    [SerializeField]
    BattlePokemon enemyPokemon;

    MoveObject enemyMove;
    MoveObject playerMove;
    bool playerIsFirst;
    bool moveIsRunning = false;
    int turn = 0;
    

    // Called when the player chooses his move
    public void ChooseMove(MoveObject move)
    {
        turn = 0;
        enemyMove = EnemyPokemonAI.GetMove(enemyPokemon);
        playerMove = move;
        playerIsFirst = playerPokemon.Pokemon.Speed > enemyPokemon.Pokemon.Speed;
        if (playerIsFirst)
        {
            PlayerAttack();
        } else
        {
            EnemyAttack();
        }
    }

    void PlayerAttack()
    {
        print("Player is attacking");
        playerPokemon.Attack(playerMove);
        finishTurn();
    }

    void EnemyAttack()
    {
        print("Enemy is attacking");
        enemyPokemon.Attack(enemyMove);
        finishTurn();
    }

    IEnumerator WaitForMoveToFinish()
    {
        moveIsRunning = true;
        bool keyIsDown = true;
        while (moveIsRunning)
        {

            if (keyIsDown)
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    keyIsDown = false;
                }
            } else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    moveIsRunning = false;
                }
            }
            yield return null;
        }
        //yield return new WaitForSeconds(3f);
        FinishMove();
    }

    void finishTurn()
    {
        turn = 1 - turn;
        StartCoroutine(WaitForMoveToFinish());
    }

    public void FinishMove()
    {
        if(turn == 1)
        {
            // We're on the second move
            if (playerIsFirst)
            {
                EnemyAttack();
            } else
            {
                PlayerAttack();
            }
        }
    }

}
