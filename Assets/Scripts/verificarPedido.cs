using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class verificarPedido : MonoBehaviour
{
    public int targetFrameRate = 60;
    public generadorDeOrdenes.IceCreamOrder currentOrder;
    private generadorDeOrdenes orderGenerator;
    private bool bandera = false;
    private float tiempoLimite = 30f;
    private float tiempoRestante;
    public float tiempoInicial = 60f;
    public float tiempoMinimo = 10f;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nuevaOrdenText; // Referencia al TextMeshProUGUI para mostrar la orden actual
    public int puntuacion = 0;
    public int vidas = 3;

    void Start()
    {
        // Encontrar el generador de órdenes en la escena
        orderGenerator = FindObjectOfType<generadorDeOrdenes>();
        // Encontrar el componente de texto en la escena
        timeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        nuevaOrdenText = GameObject.Find("OrderText").GetComponent<TextMeshProUGUI>(); // Referencia al nuevo componente de texto
        // Generar la primera orden
        GenerarNuevaOrden();
        // Configurar el Frame Rate
        Application.targetFrameRate = targetFrameRate;
    }

    void OnTriggerEnter(Collider other)
    {
        saborHelado heladoSabor = other.GetComponent<saborHelado>();
        Envase envase = other.GetComponent<Envase>();

        if (heladoSabor != null)
        {
            if (heladoSabor.saboresHelado[heladoSabor.numeroSabor] == currentOrder.Sabor)
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }
        }
        if (envase != null)
        {
            if (envase.envases[envase.numeroEnvase] == currentOrder.Envase && bandera)
            {
                Debug.Log("¡Orden correcta!");
                Destroy(other.transform.gameObject);
                ActualizarPuntuacion(puntuacion + 1);
                StopCoroutine("ContadorTiempo");
                GenerarNuevaOrden();
                bandera = false;
            }
            else
            {
                Debug.Log("Orden incorrecta.");
                Destroy(other.transform.gameObject);
                vidas--;
                bandera = false;
            }
        }
        if (vidas == 0)
        {
            Debug.Log("Juego terminado");
        }
    }

    void GenerarNuevaOrden()
    {
        currentOrder = orderGenerator.GenerarPedidoAleatorio();
        MostrarOrden();
        tiempoLimite = Mathf.Max(tiempoInicial - puntuacion * 2f, tiempoMinimo);
        StartCoroutine(ContadorTiempo(tiempoLimite));
    }

    IEnumerator ContadorTiempo(float tiempo)
    {
        tiempoRestante = tiempo;
        while (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime; // Decrementar el tiempo basado en el tiempo real transcurrido entre frames
            timeText.text = "Tiempo restante: " + Mathf.Ceil(tiempoRestante).ToString();
            yield return null; // Esperar hasta el siguiente frame
        }
        Debug.Log("Tiempo agotado para la orden.");
        GenerarNuevaOrden();
    }

    void ActualizarPuntuacion(int nuevaPuntuacion)
    {
        puntuacion = nuevaPuntuacion;
        scoreText.text = "Puntuación: " + puntuacion.ToString();
    }

    void MostrarOrden()
    {
        string ordenTexto = $"Envase: {currentOrder.Envase}\nSabor: {currentOrder.Sabor}";
        nuevaOrdenText.text = "Nueva orden:\n" + ordenTexto; // Actualizar el texto del componente TextMeshProUGUI
        Debug.Log($"Nueva orden: {currentOrder}");
    }
}
