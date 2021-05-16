using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoricalInfo : MonoBehaviour
{

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            text.SetActive(true);
            StartCoroutine("WaitForTime");

        }
    }

    public IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(35);
        text.SetActive(false);
    }
}
