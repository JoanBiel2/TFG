using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
using System.Collections;

public class FadeToBlack : MonoBehaviour
{
    private float fadeDuration = 2.5f;
    private Image image;
    private Dialogue dialogue;

    private void Awake()
    {
        image = GetComponent<Image>();
        dialogue = FindFirstObjectByType<Dialogue>();
    }

    public void FadeImage(float fadevalue) //FadeValue es entre 0 y 1, siendo 0 completamente transparente y 1 completamente opaco
    {
        Tween.Alpha(image, fadevalue, fadeDuration);
    }
    public IEnumerator FadeOutFadein()
    {
        FadeImage(1);
        dialogue.StopDialogue();
        yield return new WaitForSeconds(5f);
        dialogue.StartDialogue();
        FadeImage(0);
    }
}
