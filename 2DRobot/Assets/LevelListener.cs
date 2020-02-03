using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelListener : MonoBehaviour
{

    void Load()
    {
        if(GameManager.Instance.level == LevelState.Level_0)
        {
            SceneManager.LoadScene(2);
            //GameManager.Instance.NextGame();
        }
        if (GameManager.Instance.level == LevelState.Level_1)
        {
            SceneManager.LoadScene(3);
            GameManager.Instance.NextGame();
        }
        else if (GameManager.Instance.level == LevelState.Level_2)
        {
            SceneManager.LoadScene(4);
            GameManager.Instance.NextGame();
        }
        else if (GameManager.Instance.level == LevelState.Level_3)
        {
            SceneManager.LoadScene(5);
            GameManager.Instance.NextGame();
        }
        else if (GameManager.Instance.level == LevelState.end)
        {
            SceneManager.LoadScene(6);
            GameManager.Instance.NextGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Load",3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
