using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField] string nameScene;
    Scene scene;
    [SerializeField] GameData selectedPl;
    [SerializeField] GameObject[] spiningTop;
    [SerializeField] Transform[] spawnPt;
    [SerializeField] GameObject pauseMenu;
   
    
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

    private void Start() {
        
        scene = SceneManager.GetActiveScene();
        spawnPt[0]= GameObject.Find("SpawnPoint").GetComponent<Transform>();
        spawnPt[1]= GameObject.Find("SpawnPoint1").GetComponent<Transform>();
        
        if(scene.name == "Battle")
        {
            
            Instantiate(spiningTop[selectedPl.numberOfPlayer], spawnPt[0].position, Quaternion.identity);
            Instantiate(spiningTop[selectedPl.numberOfPlayer2], spawnPt[1].position, Quaternion.identity);
        }
        
        
    }
    
    public void PauseMenuOn()
    {
        pauseMenu.SetActive(true);    
        
    }
    public void ChargeScene()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
