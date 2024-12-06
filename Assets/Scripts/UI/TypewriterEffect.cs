using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // El texto que aparecerá
    public string fullText; // Texto completo
    public float typingSpeed = 0.05f; // Velocidad de tipeo (en segundos)
    public Image fadeImage; // Imagen para el Fade Out
    public float fadeDuration = 1f; // Duración del Fade Out
    public string nextSceneName = "MenuPrincipal"; // Escena a la que se cargará al finalizar

    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Esperar un poco después de mostrar el texto antes de iniciar el Fade Out
        yield return new WaitForSeconds(2f);

        // Iniciar el Fade Out
        StartCoroutine(FadeOut());
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

        // Asegurarse de que el color final sea completamente opaco
        fadeColor.a = 1;
        fadeImage.color = fadeColor;

        // Cargar la próxima escena
        SceneManager.LoadScene(nextSceneName);
    }
}