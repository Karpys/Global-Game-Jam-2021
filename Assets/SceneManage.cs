using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    public string Scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Scene);
        GameManager.EnnemyCount = 0;
        GameManager.Multi = 0;
        GameManager.Score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
