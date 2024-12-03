using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaMensaje : MonoBehaviour
{

    [SerializeField] private GameObject mensaje;

    private void Start()
    {
        mensaje.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("TOCO");
            mensaje.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collission)
    {
        if (collission.gameObject.tag == "Player")
        {
            mensaje.SetActive(false);
        }
    }

    

}
