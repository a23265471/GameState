using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This script exists in the Persistent scene and manages the content
// based scene's loading.  It works on a principle that the
// Persistent scene will be loaded first, then it loads the scenes that
// contain the player and other visual elements when they are needed.
// At the same time it will unload the scenes that are not needed when
// the player leaves them.
public class SceneController : MonoBehaviour
{
    public event Action BeforeSceneUnload;
    public event Action AfterSceneLoad;
    public CanvasGroup faderCancaGroup;
    public float fadeDuration;
    public string staringSceneName = "SecurityRoom";
    public string initialStartingPositionName = "DoorToMarket";
    public SaveData playerSaveData;
    private bool isFading;
    
    private IEnumerator Start()
    {
        faderCancaGroup.alpha = 1f;
        playerSaveData.Save(PlayerMovement.startingPositionKey, initialStartingPositionName);
        yield return LoadSceneAndSetAction(staringSceneName);
        StartCoroutine(Fade(0f));

    }
    // This is the main external point of contact and influence from the rest of the project.
    // This will be called by a SceneReaction when the player wants to switch scenes.
    public void FadeAndLoadScene (SceneReaction sceneReaction)
    {
        if (isFading == false)
        {
            StartCoroutine(FadeAndSwitchScene(sceneReaction.sceneName));

        }


    }

    private IEnumerator FadeAndSwitchScene(string sceneName)
    {
        yield return StartCoroutine(Fade(1f));
        if (BeforeSceneUnload != null)
            BeforeSceneUnload();
        yield return SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        yield return StartCoroutine(LoadSceneAndSetAction(sceneName));
        if (AfterSceneLoad != null)
            AfterSceneLoad();
        yield return StartCoroutine(Fade(0f));

    }

    private IEnumerator LoadSceneAndSetAction(string SceneName)
    {
        yield return SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);//非同步加載
        Scene newLoadScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newLoadScene);
    }
    private IEnumerator Fade(float finalAlpha)
    {
        isFading = true;
        faderCancaGroup.blocksRaycasts = true;
        float fadeSpeed = Math.Abs(faderCancaGroup.alpha - finalAlpha) / fadeDuration;
        while(Mathf.Approximately(faderCancaGroup.alpha,finalAlpha)==false)
        {
            faderCancaGroup.alpha = Mathf.MoveTowards(faderCancaGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;


        }
        isFading = false;
        faderCancaGroup.blocksRaycasts = false;

    }

}
