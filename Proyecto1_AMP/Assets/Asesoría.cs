using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Asesoría : MonoBehaviour
{

    public int numberQuestions;
    public int count = 0;
    public List<int> numberRandom;
    public bool stop = false;

    public GameObject[] questions;

    private void Start()
    {
        while(!stop)
        {
            int temp = Random.Range(0, numberQuestions - 1);
            if (!numberRandom.Contains(temp))
            {
                numberRandom.Add(temp);
                count++;
            }
            if (count==numberQuestions-1)
            {
                break;
            }
        }
    }
    public void ActiveQuestion()
    {
        questions[numberRandom[0]].SetActive(true);
    }

}
