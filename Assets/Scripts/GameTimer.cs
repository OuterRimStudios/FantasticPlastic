using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 120;

    public Image splashImage;
    public Color splashImageFadeColor;

    public MeshRenderer sphereMesh;
    public Color meshFadeColor;

    public float fadeSpeed = 2;

    public AudioMixer mixer;

    public GameObject environment;

    float volumeLevel;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(gameTime);
        Color splashColor = splashImage.color;
        Color sphereColor = sphereMesh.material.color;
        StartCoroutine(Fade(splashColor, sphereColor));
        StartCoroutine(FadeSounds());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Fade(Color splashColor, Color sphereColor)
    {
        yield return new WaitUntil(() => Fading(ref splashColor, ref sphereColor));

        environment.SetActive(false);
    }

    bool Fading(ref Color splashColor, ref Color sphereColor)
    {
        splashColor.a = Mathf.MoveTowards(splashColor.a, splashImageFadeColor.a, fadeSpeed * Time.deltaTime);
        sphereColor.a = Mathf.MoveTowards(sphereColor.a, meshFadeColor.a, fadeSpeed * Time.deltaTime);

        splashImage.color = splashColor;
        sphereMesh.material.color = sphereColor;
        return sphereMesh.material.color.a == 1;
    }

    IEnumerator FadeSounds()
    {
        yield return new WaitUntil(() => FadingSounds());
    }

    bool FadingSounds()
    {
        volumeLevel = Mathf.MoveTowards(volumeLevel, 0, fadeSpeed * Time.deltaTime);
        mixer.SetFloat("volume", volumeLevel);

        float testVolume;
        mixer.GetFloat("volume", out testVolume);
        return testVolume == 0;
    }
}
