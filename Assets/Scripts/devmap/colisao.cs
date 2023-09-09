using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colisao : MonoBehaviour
{
    [SerializeField] GameObject player;

    //HUD
    [SerializeField] GameObject action_hud;
    [SerializeField] TextMeshProUGUI action_text;


    [SerializeField] TextMeshProUGUI objectives_text;

    Scene scene;
    string scene_name = string.Empty;
    string tp_valor = string.Empty;


    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        scene_name = scene.name;
        action_hud.active = false;
        action_text.text = "Interação";
    }


    private void Update()
    {

        objectives_update();
        colisoes();



    }


    void objectives_update()
    {
        switch(scene_name)
        {
            case "casa":
                objectives_text.text = "- Pegar mochila\n- Ir para a escola\n- Não Aprender nada\n- Teste\n- Teste2\n- Teste3";
                break;
            case "devmap":
                objectives_text.text = "- Programar o jogo :|";
                break;
        }
    }

    void colisoes()
    {
        if (action_hud.active == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Action Key Pressed!");

                switch (tp_valor)
                {

                    case "tp_out_house":
                        SceneManager.UnloadSceneAsync("Casa");
                        SceneManager.LoadSceneAsync("Cidade");
                        break;

                }

            }
        }
    }



    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "action")
        {

            switch (other.gameObject.name)
            {
                case "action_pc":
                    action_text.text = "Interagir com o PC";

                    break;

                case "tp_out_house":
                    tp_valor = "tp_out_house";
                    action_text.text = "Sair para fora de casa";
                    break;
            }
                Debug.Log("Colisão");
                action_hud.active = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        action_hud.active = false;
    }
}
