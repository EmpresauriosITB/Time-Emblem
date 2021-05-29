using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPirateScene()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadSpainScene()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadBattle1()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void LoadBattle2()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void LoadBattle3()
    {
        StartCoroutine(LoadLevel(5));
    }

    public void LoadBattle4()
    {
        StartCoroutine(LoadLevel(6));
    }

    public void LoadBattle5()
    {
        StartCoroutine(LoadLevel(7));
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
