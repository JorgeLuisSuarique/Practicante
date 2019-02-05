using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /// <summary>
    /// variables privadas.
    /// </summary>
    private Player play;
    private Rigidbody2D rb2d;
    /// <summary>
    /// se llama en el Start los componentes de las varibles asignadas.
    /// </summary>
    void Start()
    {
        play = GetComponentInParent<Player>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    /// <summary>
    /// al colicionar con el tag la varible para tocar el suleo es verdadero.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            play.grounded = true;
        }
    }
    /// <summary>
    /// si dejo de colicionar el tag la varible para tocar el suelo es falso
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            play.grounded = false;
        }
    }
}
