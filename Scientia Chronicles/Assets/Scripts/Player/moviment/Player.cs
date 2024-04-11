//Importação de bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Variável pública que o valor poderá ser trocado quando quiser na engine
    public float speed;
    //Inicialização das variáveis que irão pegar os componentes no Player
    private Rigidbody2D rig;

    

    //Método que é chamado uma vez ao iniciar
    void Start()
    {
        //As variáveis pegam o componente do Player
        rig = GetComponent<Rigidbody2D>();
    }
    //Método que é chamado a cada frame
    void Update()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")* speed);
        ZLock();
    }


    void ZLock(){
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
    }
}