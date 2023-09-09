using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    [SerializeField] Canvas menu_pause;
    bool menu_pause_active = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu_pause.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            game_pause();
        }

        if (menu_pause_active != false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene atual = SceneManager.GetActiveScene();
                string atual_nome = atual.name;
                SceneManager.UnloadSceneAsync(atual_nome);
                Debug.Log("Liberando Scene anterior");
                Debug.Log("Scene: " + atual_nome);
                SceneManager.LoadSceneAsync("menu");
                Debug.Log("Menu Carregado!");
                
            }
        }




    }
    void game_pause()
    {
        if (menu_pause_active != true)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            menu_pause.enabled = true;
            menu_pause_active = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            menu_pause.enabled = false;
            menu_pause_active = false;
        }
    }
}
