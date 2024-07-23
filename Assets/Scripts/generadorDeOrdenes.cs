using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorDeOrdenes : MonoBehaviour
{
    // Definimos los tipos de envases y sabores de helado
    private string[] envases = { "Cono", "Vaso" };
    private string[] sabores = { "Menta", "Vainilla", "Chocolate", "Fresa", "Chicle" };

    // Clase para representar un pedido de helado
    public class IceCreamOrder
    {
        public string Envase;
        public string Sabor;

        public IceCreamOrder(string envase, string sabor)
        {
            Envase = envase;
            Sabor = sabor;
        }

        public override string ToString()
        {
            return $"{Envase} de {Sabor}";
        }
    }

    // Método para generar un pedido aleatorio
    public IceCreamOrder GenerarPedidoAleatorio()
    {
        string envaseAleatorio = envases[Random.Range(0, envases.Length)];
        string saborAleatorio = sabores[Random.Range(0, sabores.Length)];
        return new IceCreamOrder(envaseAleatorio, saborAleatorio);
    }

}
