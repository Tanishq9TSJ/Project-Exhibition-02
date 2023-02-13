using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectivesComplete : MonoBehaviour
{
    public Text objective1;
    public Text objective2;
    public Text objective3;
    public Text objective4;
    public Text objective5;
    public Text objective6;
    public Text objective7;
    public Text objective8;
    public Text objective9;
    public Text objective10;

    public static ObjectivesComplete occurrence;
    private void Awake()
    {
        occurrence = this;
    }
    private void Start()
    {
        objective1.enabled = true;
        objective2.enabled = true;
        objective3.enabled = true;
        objective4.enabled = true;
        objective5.enabled = true;
        objective6.enabled = true;
        objective7.enabled = true;
        objective8.enabled = true;
        objective9.enabled = true;
        objective10.enabled = true;
    }
    public void GetObjectivesDone(bool obj1, bool obj2, bool obj3, bool obj4, bool obj5, bool obj6, bool obj7, bool obj8, bool obj9, bool obj10)
    {
        if(obj1 == true) 
        {
            objective1.color = Color.green;
            objective1.text = "Prison Reached";
            //bjective1.color = Color.green;
        }
        else
        {

            objective1.text = "Reach The Prison";
            //objective1.color = Color.red;
        }
        if(obj2 == true)
        {
            objective2.color = Color.green;
            objective2.text = "Weapon Occupied";
        }
        else
        {
            objective2.text = "Pick Up Weapon";
        }
    }
}
