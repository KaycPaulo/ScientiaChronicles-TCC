using UnityEngine;

public class NPCFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    private bool isFacingRight = true; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    
    public void Flip()
    {
        if (isFacingRight)
        {
            
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        isFacingRight = !isFacingRight;
    }
}
