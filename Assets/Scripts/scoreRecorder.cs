using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class scoreRecorder : MonoBehaviour
{
    void Start()
    {
        double score = GameController.score; // Get the score from GameController
        StartCoroutine(PostData(score));
    }

    IEnumerator PostData(double score)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", score.ToString()); // Add the score to the form

        UnityWebRequest www = UnityWebRequest.Post("https://replit.com/@UnknownTerence/ICS4UFinalSummative#scoreboard/process.php", form); // Replace with your Replit URL
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string results = www.downloadHandler.text;
            Debug.Log(results);
        }
        www.Dispose();
    }
}
