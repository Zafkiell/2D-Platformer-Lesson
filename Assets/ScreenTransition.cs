using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
   public GameObject fadeCircle;
   public void Transition(string method,float timer)
    {
        Invoke(method, timer);
    }
    void FadeIn()
    {
        fadeCircle.GetComponent<Animator>().SetTrigger("FadeIn");
    }
}
