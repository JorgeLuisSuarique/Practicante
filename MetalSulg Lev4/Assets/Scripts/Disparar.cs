using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    /// <summary>
    /// variable privada
    /// </summary>
    private Rigidbody2D bullRb2d;
    private Transform playTrans;
    private GameObject player;
    /// <summary>
    /// variables publicas
    /// </summary>
    public float bullSpeed;
    public float bullLife;
    /// <summary>
    /// se asiganan dichos componentes lasa varibles llamadas en el Awake.
    /// </summary>
    void Awake()
    {
        bullRb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playTrans = player.transform;
    }
    /// <summary>
    /// se crea la funciones de la velocidad y la direcion del prefab
    /// </summary>
    void Start ()
    {
        if (playTrans.localScale.x > 0)
        {
            bullRb2d.velocity = new Vector2(bullSpeed, bullRb2d.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            bullRb2d.velocity = new Vector2(-bullSpeed, bullRb2d.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    /// <summary>
    /// se destruye el objeto despues de un tiempo
    /// </summary>
    void FixedUpdate()
    {
        Destroy(gameObject, bullLife);
    }
    /// <summary>
    /// al colicionar con el tag el objeto se destruye
    /// </summary>
    /// <param name="coll"></param>
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
