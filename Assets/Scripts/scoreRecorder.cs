using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreRecorder : MonoBehaviour
{
    void Start()
    {
        double score = GameController.score; // Get the score from GameController
        StartCoroutine(SendScoreToServer(score));
    }

    IEnumerator SendScoreToServer(double score)
    {
        // Local URL within the WebGL build
        string url = Application.streamingAssetsPath + "/process.php";

        WWWForm form = new WWWForm();
        form.AddField("score", score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Score successfully sent to server");
            }
        }
    }
}
