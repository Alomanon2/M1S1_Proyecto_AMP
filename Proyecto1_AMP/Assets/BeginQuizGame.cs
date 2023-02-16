using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginQuizGame : MonoBehaviour
{
        public GameObject canvasInicio, canvasPreguntas,canvasFinal;

        void Start()
        {
            canvasInicio.SetActive(true);
            canvasPreguntas.SetActive(false);
            canvasFinal.SetActive(false);
        }
        public void BeginQuiz()
        {
            canvasInicio.SetActive(false);
            canvasPreguntas.SetActive(true);
        }
        public void EndQuiz()
        {
            canvasInicio.SetActive(false);
            canvasPreguntas.SetActive(false);
            canvasFinal.SetActive(true);
        }
}
