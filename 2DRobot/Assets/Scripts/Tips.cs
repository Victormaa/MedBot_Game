using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    SpriteRenderer r;
    [SerializeField]
    GameObject FlowChat;

    [SerializeField]
    GameObject RobotPointLight;

    // Start is called before the first frame update
    void Start()
    {
        r = this.GetComponent<SpriteRenderer>();
    }

    bool a = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlowChat.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    [SerializeField]
    GameObject RedLight;
    public void LightOn()
    {
        RedLight.SetActive(true);
        RobotPointLight.SetActive(false);
    }

}
