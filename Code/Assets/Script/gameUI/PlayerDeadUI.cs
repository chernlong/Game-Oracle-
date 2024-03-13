using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadUI : MonoBehaviour
{
    public GameObject DeadUI;

    // Start is called before the first frame update
    void Start()
    {
        /*playerDie = GameObject.FindObjectOfType<PlayerController>();*/
        //PlayerController.instance.Die();
        DeadUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.alive == false)
        {
            DeadUI.SetActive(true);
            //Debug.Log("im in");
        }
        /*else
        {
            Debug.Log("+++++");
        }*/
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GobackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
