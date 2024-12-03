using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rPlayer;
    private Animator aPlayer;
    private float h;
    private Vector3 posIni;

    public float velocidad;
    public float velocidadMax;
    public float fuerzaSalto;
    public float friccionSuelo;
    public bool colPies = false;

    private bool miraDerecha = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rPlayer = GetComponent<Rigidbody2D>();
        aPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        giraPlayer(h);
        aPlayer.SetFloat("VelocidadX", Mathf.Abs(rPlayer.linearVelocity.x));
        aPlayer.SetFloat("VelocidadY", rPlayer.linearVelocity.y);
        aPlayer.SetBool("TocaSuelo", colPies);

        // SALTO
        colPies = CheckGround.colPies;
        if (Input.GetButtonDown("Jump") && colPies)
        {
            rPlayer.linearVelocity = new Vector2(rPlayer.linearVelocity.x, 0f);
            rPlayer.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("Quita salud");
            pierdeVida();
        }
    }

    private void pierdeVida()
    {
        Debug.Log("Te Atraparon");
        reaparece();
    }

    private void reaparece()
    {
        rPlayer.linearVelocity = Vector3.zero;
        transform.position = posIni;
    }


    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        rPlayer.AddForce(Vector2.right * velocidad * h);
        float limiteVelocidad = Mathf.Clamp(rPlayer.linearVelocity.x, -velocidadMax, velocidadMax);
        rPlayer.linearVelocity = new Vector2(limiteVelocidad, rPlayer.linearVelocity.y);
        if (h ==0 && colPies)
        {
            Vector3 velocidadArreglada = rPlayer.linearVelocity;
            velocidadArreglada.x *= friccionSuelo;
            rPlayer.linearVelocity = velocidadArreglada; 
        }
    }

    void giraPlayer(float horizontal)
    {
        if ((horizontal > 0 && !miraDerecha) || horizontal < 0 && miraDerecha)
        {
            miraDerecha = !miraDerecha;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x = escalaGiro.x * -1;
            transform.localScale = escalaGiro;
        }
    }

}