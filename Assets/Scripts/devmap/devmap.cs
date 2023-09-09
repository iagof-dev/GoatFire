using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class devmap : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] TextMeshProUGUI obj_si;
    [SerializeField] Camera Camera;
    [SerializeField] Camera freecam;

    [SerializeField] Canvas menu_dev;
    [SerializeField] Canvas menu_pause;




    [SerializeField] GameObject teleportador;
    [SerializeField] GameObject hitbox;


    bool menu_pause_active = false;
    bool show_perf = false;

    public static string scene = string.Empty;


    // Start is called before the first frame update
    void Start()
    {
        freecam.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        menu_dev.enabled = true;
        menu_pause.enabled = false;
        Time.timeScale = 1;
        Scene active_scene = SceneManager.GetActiveScene();
        scene = active_scene.name;
        obj_si.enabled = false;
        SceneManager.UnloadSceneAsync("Menu");


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Camera.enabled = false;
            freecam.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.F1))
        {
            Camera.enabled = true;
            freecam.enabled = false;
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            game_pause();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            obj_si.enabled = true;
            obj_si.text = ($"System Info\nP:{SystemInfo.processorType}" +
            $"\nG:{SystemInfo.graphicsDeviceName}" +
            $"\nRam: 0/{System.GC.GetTotalMemory(false)}" +
            $"\nFPS: {(1.0f / Time.deltaTime)}" +
            $"\nMap: {scene}");
            show_perf = true;
        }
        if (Input.GetKeyUp(KeyCode.F3))
        {
            obj_si.enabled = false;
            show_perf = false;
        }




    }

    void game_pause()
    {
        if (menu_pause_active != true)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            menu_dev.enabled = false;
            menu_pause.enabled = true;
            menu_pause_active = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            menu_dev.enabled = true;
            menu_pause.enabled = false;
            menu_pause_active = false;
        }
    }






}
