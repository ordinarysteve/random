using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FirstCutscene : MonoBehaviour
{

    public PlayableDirector director1, director2;
    public GameObject canvas, question, firstText, secondText;
    public string sceneName;

    private void Start()
    {
        //director1 = GetComponent<PlayableDirector>();
        //director1.played += director1_played;
        director1.stopped += director1_stopped;
        // director2.played += director2_played;
        director2.stopped += director2_stopped;
        question.SetActive(false);
    }

    /*private void director1_played(PlayableDirector obj)
    {
        Debug.Log("First cutscene played");
    }*/
    private void director1_stopped(PlayableDirector obj)
    {
        canvas.SetActive(true);
        question.SetActive(true);
        firstText.SetActive(false);
        secondText.SetActive(false);
    }
    private void director2_stopped(PlayableDirector obj)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void question_yes()
    {
        question.SetActive(false);
        firstText.SetActive(false);
        director2.Play();
    }
    public void question_no()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
