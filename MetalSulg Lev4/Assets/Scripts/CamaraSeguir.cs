﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    /// <summary>
    /// variables publicas
    /// </summary>
    public GameObject target;
    public Vector2 minCP, maxCP;
    public float smooth;
    /// <summary>
    /// variable privada
    /// </summary>
    private Vector2 vel;
    /// <summary>
    /// en el FixedUpdate se crea las funciones para que la camara siga a un target.
    /// </summary>
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref vel.x, smooth);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref vel.y, smooth);
        transform.position = new Vector3(Mathf.Clamp(posX, minCP.x, maxCP.x), Mathf.Clamp(posY, minCP.y, maxCP.y), transform.position.z);
    }
}
