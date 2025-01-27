using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum FadeState { In, FadingOut, FadingIn, Out }
public class FadeManager : MonoBehaviour
{
    private Image im;
    private float CurrentAlpha = 0;
    public static FadeManager Instance;
    public FadeState State = FadeState.FadingOut;
    // Start is called before the first frame update
    void Start()
    {
        CurrentAlpha = 1;
        im = GetComponent<Image>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == FadeState.In)
        {
            Time.timeScale = 0;
            //Dead
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (State == FadeState.FadingIn)
        {
            Time.timeScale = 0;
            CurrentAlpha += Time.unscaledDeltaTime;
            if (CurrentAlpha >= 1)
            {
                State = FadeState.In;
            }
        }
        else if (State == FadeState.Out)
        {
            Time.timeScale = 1;
            //Alive
        }
        else if (State == FadeState.FadingOut)
        {
            Time.timeScale = 0;
            CurrentAlpha -= Time.unscaledDeltaTime;
            if (CurrentAlpha <= 0)
            {
                State = FadeState.Out;
            }
        }
        im.color = new Color(0, 0, 0, CurrentAlpha);
    }
}
