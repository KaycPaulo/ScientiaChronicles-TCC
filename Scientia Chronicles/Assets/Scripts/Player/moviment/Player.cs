using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Variável pública que o valor poderá ser trocado quando quiser na engine
    public Animator playercontroller;
    bool isWalking = false;
    float inputX = 0, inputY = 0;
    public float speed;
    //Inicialização das variáveis que irão pegar os componentes no Player
    private Rigidbody2D rig;

    

    //Método que é chamado uma vez ao iniciar
    void Start()
    {
        //As variáveis pegam o componente do Player
        rig = GetComponent<Rigidbody2D>();
        isWalking = false;
    }
    //Método que é chamado a cada frame
    void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(inputX*speed, inputY*speed);

        isWalking = (inputX != 0 || inputY != 0);

        if(isWalking){

            Vector2 Movement = new Vector2(inputX, inputY).normalized;
            rig.velocity = Movement*speed;
            playercontroller.SetFloat("input_x", inputX);
            playercontroller.SetFloat("input_y", inputY);
        }
        playercontroller.SetBool("isWalking", isWalking);

        if (inputX < 0){
            playercontroller.transform.localScale = new Vector3(-1, 1, 1); // Inverte a escala horizontalmente
        }
        else if (inputX > 0){
            playercontroller.transform.localScale = new Vector3(1, 1, 1); // Restaura a escala original
        }
    }
}