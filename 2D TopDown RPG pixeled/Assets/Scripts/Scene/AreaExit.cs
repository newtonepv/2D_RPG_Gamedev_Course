using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaExit : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] string sceneName;
    [SerializeField] string entranceName;
    Coroutine waitAndChangeScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerController>()!=null)
        {
            if (waitAndChangeScene == null)
            {
                waitAndChangeScene = StartCoroutine(WaitAndChangeScene());
            }
        }
    }
    IEnumerator WaitAndChangeScene()
    {

        FadeScript.Instance.FadeToBlack();
        SceneManagmentScript.Instance.SetEntrance(entranceName);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);

    }
}
