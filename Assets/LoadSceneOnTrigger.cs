using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public string sceneToLoad = "3 Level Complete"; // Der Name der zu ladenden Szene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
           {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
