using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryController inventoryController;
    public Animator playercontroller;
    private Vector2 Movement;
    float inputX = 0, inputY = 0;
    private Rigidbody2D rig;
    private bool canMove = true;
    public float speed;
    bool isWalking = false;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        isWalking = false;
    }

    //O Método fixedUpdate que é chamado a cada frame!! 
    void FixedUpdate()
    {
        if (!canMove)
        {
            rig.velocity = Vector2.zero;
            isWalking = false;
            Animation();
            return;
        }
        
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(inputX * speed, inputY * speed);

        isWalking = (inputX != 0 || inputY != 0);

        if (isWalking)
        {

            Movement = new Vector2(inputX, inputY).normalized;
            rig.velocity = Movement * speed;
            playercontroller.SetFloat("input_x", inputX);
            playercontroller.SetFloat("input_y", inputY);
        }
        Animation();

    }

    private void Animation()
    {
        playercontroller.SetBool("isWalking", isWalking);

        if (inputX < 0)
        {
            playercontroller.transform.localScale = new Vector3(-1, 1, 1); // Inverte a escala horizontalmente
        }
        else if (inputX > 0)
        {
            playercontroller.transform.localScale = new Vector3(1, 1, 1); // Restaura a escala original
        }
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableMovement(){
        canMove = true;
    }
}