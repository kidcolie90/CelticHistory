using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//reference to code : https://forum.unity.com/threads/creating-a-basic-dialogue-window.494649/


    //class is used an object passed into dialogue manager whenver a new dialouge is started, used for amount and size of sentences and name of god


[System.Serializable]
public class Dialogue 
{

    public string name;


    [TextArea(3,10)]

    public string[] sentences; 





  
}
