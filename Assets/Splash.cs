using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash: MonoBehaviour {
    
    private void Update()
    {
        transform.Rotate(new Vector3(0f, .03f, 0f));
        Invoke("LoadFirstScene", 8f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
