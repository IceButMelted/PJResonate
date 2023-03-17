using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Loadnext_easy_ver : MonoBehaviour
{
    public Animator transiton;
    public string nameScene;

    public void LoadNextLevel()
    {
        StartCoroutine(Transition(nameScene));
    }

    IEnumerator Transition(string sceneName) 
    {
        transiton.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    } 
}
