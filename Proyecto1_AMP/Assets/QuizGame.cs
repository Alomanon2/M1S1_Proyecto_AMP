using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    public GameObject canvasInicio, canvasPreguntas, canvasFinal,botonTerminarJuego,reportePuntosFinales;

    public GameObject[] arrayQuestions;
    public List<int> randomList;
    public int totalQuestions;
    
    private int count1 = 0, count2 = 0;
    private int puntos=0;
    private bool stop = false;

    public TextMeshProUGUI textPuntos, textPuntosFinales;
    public GameObject panelDisableAnswers;
    public Button[] arrayCorrectAnswers;

    private void Start()
    {
        canvasInicio.SetActive(true);
        canvasPreguntas.SetActive(false);
        canvasFinal.SetActive(false);
        reportePuntosFinales.SetActive(false);
        panelDisableAnswers.SetActive(false);
        textPuntos.text = "Puntos: " + puntos.ToString();
    }

    public  void StartGame()
    {

        while (!stop)
        {
            int random = UnityEngine.Random.Range(0, totalQuestions);
            if (!randomList.Contains(random))
            {
                randomList.Add(random);
                count1++;
            }
            if (count1 == totalQuestions)
            {
                stop = true;
                break;
            }
        }
        CurrentQuestion();
    }   
    public void CurrentQuestion()
    {
        if (count2 == totalQuestions)
        {
            canvasPreguntas.SetActive(false);
            canvasFinal.SetActive(true);
        }
        else
        {
            canvasInicio.SetActive(false);
            canvasPreguntas.SetActive(true);
        }
        if (count2!=0)
        {
            panelDisableAnswers.SetActive(false);
            arrayQuestions[randomList[count2-1]].SetActive(false);
            //print("Se desactiva la posicion del array: " + randomList[count2-1]); 
            arrayQuestions[randomList[count2]].SetActive(true);
            //print("Se activa la posicion del array: " + randomList[count2]);
            count2++;
            //print("Count2 vale: " + count2);
            textPuntos.text = "Puntos: " + puntos.ToString();
            //print("Puntos:" + puntos);
        }
        else
        {
            arrayQuestions[randomList[count2]].SetActive(true);
            //print("Se activa la posicion del array: " + randomList[count2]);
            count2++;
            //print("Count2 vale: " + count2);
            textPuntos.text = "Puntos: " + puntos.ToString();
            //print("Puntos:" + puntos);
        }
    }

    public IEnumerator CorrectOptionCoroutine(Button opcionCorrecta)
    {
        opcionCorrecta.image.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        puntos = puntos + 100;
        CurrentQuestion();
    }
    
    public void CorrectOption(Button opcionCorrecta)
    {
        panelDisableAnswers.SetActive(true);
        StartCoroutine(CorrectOptionCoroutine(opcionCorrecta)); 
    }

    public IEnumerator IncorrectOptionCoroutine(Button opcionIncorrecta)
    {
        opcionIncorrecta.image.color = Color.red;
        arrayCorrectAnswers[randomList[count2-1]].image.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        puntos = puntos + 0;
        CurrentQuestion();

    }
    public void IncorrectOption(Button opcionIncorrecta)
    {
        panelDisableAnswers.SetActive(true) ;    
        StartCoroutine(IncorrectOptionCoroutine(opcionIncorrecta));
    }
    public void FinishGame()
    {
        panelDisableAnswers.SetActive(false); 
        if (puntos==800)
        {
            textPuntosFinales.text = "¡Felicidades! Obtuviste la máxima puntuación: " + puntos.ToString() + " puntos.";
        }
        else
        {
            textPuntosFinales.text = "Respondiste "+puntos/100+"/8 respuestas correctamente. Obtuviste: " + puntos.ToString() + " puntos!";
        }
        botonTerminarJuego.SetActive(false);
        reportePuntosFinales.SetActive(true);
    }

}
