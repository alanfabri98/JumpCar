using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadMov;
    public float velocidadRot;
    private int cont;

    void star()
    {
        velocidadMov = 10.0f;
        velocidadRot = 100.0f;
        cont = 0;
    }

    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidadMov * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * velocidadRot * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        cont = cont + 250;
        Debug.Log(cont);

        if (cont == 1000)
        {
            Debug.Log("GANASTE!!");
        }
    }

}
