using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{

    public static CamController instance;

    public CinemachineBrain cineBrain;

    public void awake()
    {

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
