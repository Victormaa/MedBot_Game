using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hangover : MonoBehaviour
{

    [SerializeField]
    GameObject A;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mouverover()
    {
        A.SetActive(true);
    }
    public void Mouseexit()
    {
        A.SetActive(false);
    }
}
