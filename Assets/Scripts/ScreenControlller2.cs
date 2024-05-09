using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenControlller2 : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScreenControlller2 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("GameOver");
    }
}
