using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage; // Referencia al panel de fade
    public float fadeDuration = 1f; // Duración del fade
    public bool startWithFadeIn = true; // Controla si se inicia con Fade In
    // public string nextSceneName = "MenuPrincipal";

    void Start()
    {
        if (startWithFadeIn)
        {
            StartCoroutine(FadeIn());
        }
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        float timer = fadeDuration;
        Color color = fadeImage.color;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = timer / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;
        fadeImage.raycastTarget = false; // Permitir clics después del Fade In
    }

    public IEnumerator FadeOut()
    {
        fadeImage.raycastTarget = true; // Bloquear clics durante el Fade Out
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

        //Cargar la próxima escena
        GameManager.instance.play();
    }
}
