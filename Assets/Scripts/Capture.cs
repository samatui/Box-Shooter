using UnityEngine;
using System.Collections;

// Capture frames as a screenshot sequence. Images are
// stored as PNG files in a folder - these can be combined into
// a movie using image utility software (eg, QuickTime Pro).

public class Capture : MonoBehaviour
{
    // The folder to contain our screenshots.
    // If the folder exists we will append numbers to create an empty folder.
    public string folder = "ScreenshotFolder";
    public int frameRate = 30;
    private float videoTime = 0;
    void Start()
    {
        // Set the playback framerate (real time will not relate to game time after this).
        //Time.captureDeltaTime = 1.0f / 10;

        // Create the folder
        System.IO.Directory.CreateDirectory(folder);
    }

    void Update()
    {
        videoTime += Time.deltaTime;
        if (videoTime >= (1f / (float)frameRate))
        {

            // Append filename to folder name (format is '0005 shot.png"')
            string name = string.Format("{0}/{1}.png", folder, videoTime.ToString("0.00"));

            // Capture the screenshot to the specified file.
            ScreenCapture.CaptureScreenshot(name);
        }
    }
}