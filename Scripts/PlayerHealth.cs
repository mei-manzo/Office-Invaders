using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CanvasManager))]
public class PlayerHealth : Destructable
{
    [SerializeField] Animator animator;
    public Transform mainCamera;
    private GameObject player;
    public TextMeshProUGUI gameOverText;

    public RawImage backDrop;
    public Button restartButton;
    public bool isGameActive;
    public Button button;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        button = GetComponent<Button>();
 
    }


    public override void Die()
    {
        base.Die();
       
        animator.SetBool("IsDying", true);
        print("Player died");
        gameOverScreen.gameObject.SetActive(true);
  

    }
    
    public void StartGame()
    {
        isGameActive = true;
        backDrop.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
    }
    public void quitGame()
    {

        Application.Quit();
        print("game quitted");
        isGameActive = false;
    }
    public void RestartGame()
    {
     
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
     
    }
 
}
