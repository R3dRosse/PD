using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Elementos de menú")]
    [SerializeField] SpriteRenderer startButton;  

    [Header("Sonidos de menú")]
    [SerializeField] AudioSource snd_ambiente;  
    [SerializeField] AudioSource snd_start; 

    int opcionMenu = 1;  
    bool pulsadoSubmit = false;  

    void Start()
    {
        if (snd_ambiente != null)
            snd_ambiente.Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && !pulsadoSubmit)
        {
            pulsadoSubmit = true;  
            snd_start.Play();
            if (opcionMenu == 1) SceneManager.LoadScene("Nivel1");
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
