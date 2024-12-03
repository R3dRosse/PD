using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private Transform destino;
    [SerializeField] private float velocidad;

    private Vector3 posIni, posFin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destino.parent = null;
        posIni = transform.position;
        posFin = destino.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);
        if (transform.position == destino.position)
        {
            destino.position = (destino.position == posFin) ? posIni : posFin;
        }
    }
}
