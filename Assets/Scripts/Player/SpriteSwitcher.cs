using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSwitcher : MonoBehaviour {

    [SerializeField]
    Sprite northSprite;
    [SerializeField]
    Sprite southSprite;
    [SerializeField]
    Sprite eastSprite;
    [SerializeField]
    Sprite westSprite;

    SpriteRenderer spriteRenderer;
    Direction currentDirection;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentDirection = Direction.South;
    }

    public void SetSprite(Direction dir)
    {

        if(dir != currentDirection)
        {
            switch (dir)
            {
                case Direction.North:
                    spriteRenderer.sprite = northSprite;
                    break;
                case Direction.South:
                    spriteRenderer.sprite = southSprite;
                    break;
                case Direction.East:
                    spriteRenderer.sprite = eastSprite;
                    break;
                case Direction.West:
                    spriteRenderer.sprite = westSprite;
                    break;
            }

            currentDirection = dir;
        }
    }

}
