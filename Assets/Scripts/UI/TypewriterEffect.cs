using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // El texto que aparecerá
    public string[] dialogues; // Array de textos para cada imagen
    public float typingSpeed = 0.05f; // Velocidad de tipeo (en segundos)
    public Image fadeImage; // Imagen para el Fade Out/In
    public float fadeDuration = 1f; // Duración del Fade Out/In
    public string nextSceneName = "MenuPrincipal"; // Escena a la que se cargará al finalizar

    public Image[] images; // Lista de imágenes para mostrar en secuencia
    public float imageDisplayTime = 2f; // Tiempo que cada imagen estará visible

    private int currentImageIndex = 0;

    void Start()
    {
        StartCoroutine(FadeIn()); // Comenzar con Fade In
    }

    IEnumerator FadeIn()
    {
        float timer = fadeDuration;
        Color fadeColor = fadeImage.color;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            fadeColor.a = timer / fadeDuration;
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 0;
        fadeImage.color = fadeColor;
        fadeImage.raycastTarget = false; // Permitir clics después del Fade In

        // Después del Fade In, iniciar el texto y las imágenes
        StartCoroutine(ShowTextAndImages());
    }

    IEnumerator ShowTextAndImages()
    {
        for (int i = 0; i < images.Length; i++)
        {
            currentImageIndex = i;

            // Mostrar la imagen actual
            images[i].gameObject.SetActive(true);

            // Mostrar el texto correspondiente con efecto de tipeo
            yield return StartCoroutine(ShowTypingEffect(dialogues[i]));

            // Esperar el tiempo definido para leer
            yield return new WaitForSeconds(imageDisplayTime);

            // Fade out de la imagen actual (excepto la última)
            if (i < images.Length - 1)
            {
                images[i].gameObject.SetActive(false);
            }
        }

        // Iniciar el Fade Out y cambiar de escena
        StartCoroutine(FadeOut());
    }

    IEnumerator ShowTypingEffect(string text)
    {
        textComponent.text = ""; // Reiniciar el texto
        for (int i = 0; i <= text.Length; i++)
        {
            textComponent.text = text.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeOut()
    {
        fadeImage.raycastTarget = true; // Bloquear interacción durante el Fade
        float timer = 0;
        Color fadeColor = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = timer / fadeDuration;
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 1;
        fadeImage.color = fadeColor;

        // Cargar la próxima escena
        SceneManager.LoadScene(nextSceneName);
    }
}