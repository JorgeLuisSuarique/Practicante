using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// variables publicas
    /// </summary>
    public float speed = 2f;
    public bool grounded;
    public float jumPower = 6.5f;
    public Transform blasterSpawner;
    public GameObject blasPrefab;
    /// <summary>
    /// variables privadas
    /// </summary>
    private Rigidbody2D rb2d;
    private Animator anim;
    bool jump;
    bool ver;

    /// <summary>
    /// se llama en el Start los componentes asignados
    /// de las variables.
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ver = blasterSpawner;
    }
    /// <summary>
    /// en el Update se llama un flotante y un buleano con la variable de animacion
    /// luego se crea una funcion donde si el personaje esta tocando el suelo el podra saltar
    /// con la barra espaciadora y se llama el parametro de diparar.
    /// </summary>
    void Update()
    {
        anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grouded", grounded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
              jump = true;
            }
        }
        Fire();
    }
    /// <summary>
    /// se crea un parametro para disparar con click derecho.
    /// </summary>
    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(blasPrefab, blasterSpawner.position, blasterSpawner.rotation);
            anim.SetBool("Fire", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            anim.SetBool("Fire",false);
        }
    }
    /// <summary>
    /// se crea el FixeUpdate se crea las funciones y se asignas la varibles para
    /// el movimiento del personaje.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 fixVel = rb2d.velocity;
        fixVel.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixVel;
        }

        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);

        if (h > 0.1f)
        {
          transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
          transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumPower, ForceMode2D.Impulse);
            jump = false;
        }
    }
    /// <summary>
    /// si el personaje no se ve se respaunea en estas cordenadas
    /// </summary>
    void OnBecameInvisible()
    {

        transform.position = new Vector3(-10.09f, 0, -10f);
    }
}
