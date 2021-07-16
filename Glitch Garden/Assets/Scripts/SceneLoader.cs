using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    //config
    [SerializeField] float waitTime = 3.0f;

    //state
    int currentSceneIndex;


    // Start is called before the first frame update
    void Start()
    {   
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
            StartCoroutine("LoadStartScene");
    }

    IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
