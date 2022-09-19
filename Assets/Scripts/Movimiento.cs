using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public static Movimiento instance;

    public AudioClip JumpSound; //Sonido de Salto
    public GameObject bullet; //Importamos el objeto bala para disparar
    public float Speed;
    public int CurrentHealth;
    public int MaxHealth;
    public float JumpForce; //Se define la fuerza de salto

    private Rigidbody2D Rigidbody2D;  //Para el salto y moverse
    private Animator Animator; //Para las animaciones
    private float Horizontal; //Para moverse
    private bool Grounded; //Para evitar salto infinito
    private bool DoubleJump; //Para el doble salto
    private float LastShoot; //Cooldown Al disparar

    private void Awake()
    {
        instance = this;
    }

    void Start() //Al inicio
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //Obtenemos la ubicacion del eje x

        if (Horizontal < 0.0f)                                      //
        {                                                           //
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);  //
        }                                                           //
        else if (Horizontal > 0.0f)                                 // Para que gire 
        {                                                           //
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   //
        }                                                           //

        Animator.SetBool("running", Horizontal != 0.0f); //Animacion de correr

        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))  //
        {                                                               //
            Grounded = true;                                            //
        }                                                               //Define si estamos en el suelo o no
        else                                                            //
        {                                                               //
            Grounded = false;                                           //
        }                                                               //

        if(Grounded)
        {
            DoubleJump = true;
        }

        Animator.SetBool("jumping", Grounded == false); //Animacion del salto

        if (Input.GetKeyDown(KeyCode.W))// && Grounded) //
        {                                               //
            Jump();                                     //Ejecuta el salto
        }                                               //

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)   //
        {                                                                   //
            Shoot();                                                        //Ejecuta el disparo
            LastShoot = Time.time;                                          //Guarda el cooldown del disparo
        }                                                                   //
    }

    private void Jump()
    {
        if (Grounded)
        {
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
        }
        else
        {
            if (DoubleJump)
            {
                Rigidbody2D.AddForce(Vector2.up * JumpForce);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
                DoubleJump = false;
            }
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;


        GameObject Bullet = Instantiate(bullet, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<Bala>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        CurrentHealth--;
     Animator.SetTrigger("hurting");
        if (CurrentHealth <= 0) Destroy(gameObject);

        UIcontroller.instance.UpdateHealthDis();
    }
}
