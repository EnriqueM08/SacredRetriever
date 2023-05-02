using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningSceneHandler : MonoBehaviour
{
    public Text narrativeTxt;
    public AudioSource narration1;
    public AudioSource narration2;
    public AudioSource narration3;
    public AudioSource narration4;

    private void OnSkip() {
        SceneManager.LoadScene("MainMenu");
    }

    void Start() {
        StartCoroutine(narration());
    }

    IEnumerator narration() {
        narration1.Play();
        yield return new WaitForSeconds(10f);
        narrativeTxt.text = "An adventurer stumbles upon one of these treasures and decides to learn more about them and their abilities!";
        narration2.Play();
        yield return new WaitForSeconds(9f);
        narrativeTxt.text = "Now where will your journey take you? And who will you be? A fearless knight wanting glory?";
        narration3.Play();
        yield return new WaitForSeconds(9f);
        narrativeTxt.text = "Or perhaps you will be a wizard hoping to gather the 3 artifacts for limitless power! Either way, your journey will begin here...";
        narration4.Play();
        yield return new WaitForSeconds(13f);
        SceneManager.LoadScene("MainMenu");
    }
}
