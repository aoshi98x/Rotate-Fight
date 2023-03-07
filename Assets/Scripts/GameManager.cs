using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField] string nameScene;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance!= this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    public void ChargeScene()
    {
        SceneManager.LoadScene(nameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
