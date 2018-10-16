using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Direction currentDirection;
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float time;

    public float walkSpeed = 1f; // was 3
    	
    public void Move(Direction direction)
    {
        // Only react if player is not already moving
        if (!isMoving)
        {
            // If already facing in the input direction
            if (currentDirection == direction)
            {
                Vector2 input;
                // Set input vector depending on the direction
                switch (direction)
                {
                    case Direction.North:
                        input = Vector2.up;
                        break;
                    case Direction.South:
                        input = Vector2.down;
                        break;
                    case Direction.East:
                        input = Vector2.right;
                        break;
                    case Direction.West:
                        input = Vector2.left;
                        break;
                    default:
                        input = Vector2.down;
                        break;
                }
                StartCoroutine(MoveCoroutine(transform, input));

            }
            else
            {
                currentDirection = direction;
            }
        }
    }

    IEnumerator MoveCoroutine(Transform entity, Vector2 _input)
    {
        isMoving = true;
        startPos = entity.position;
        time = 0f;

        endPos = new Vector3(startPos.x + Math.Sign(_input.x), startPos.y + Math.Sign(_input.y), startPos.z);

        while (time < 1f)
        {
            time += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }

        isMoving = false;
    }
    
}