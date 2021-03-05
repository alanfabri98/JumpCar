using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    //Variables para la vida
    public float vida = 100;
    public Image barraDeVida;
    /////

    // Update is called once per frame
    void Update()
    {
        /// cambios para la barra de vida
        vida =Mathf.Clamp(vida, 0, 100);
        barraDeVida.fillAmount = vida;
    }
}
