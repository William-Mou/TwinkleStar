using SFB;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlanetIntroManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject template;
    public Scrollbar scrollbar;
    public Button pauseButton;
    public Button screenshotButton;

    private int iter;
    private bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        iter = 1;
        Application.targetFrameRate = 60;
        GameObject planet1 = Instantiate(template, new Vector3(100, 0, 0), Quaternion.identity, parent.transform);
        planet1.name = "Alzir";
        GameObject planet2 = Instantiate(template, new Vector3(-25, 0, 0), Quaternion.identity, parent.transform);
        planet2.name = "Antares";
        scrollbar.onValueChanged.AddListener((float val) => ScrollbarCallback(val));
        pauseButton.onClick.AddListener(() => PauseButtonCallback());
        screenshotButton.onClick.AddListener(() => ScreenshotButtonCallback());
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            parent.transform.eulerAngles = new Vector3(0, 1 * iter, 0);
            scrollbar.value = (float)iter / 720;
            iter %= 720;
            iter++;
        };
    }

    void ScrollbarCallback(float value)
    {
        if (pause)
        {
            iter = (int)(value * 720);
            parent.transform.eulerAngles = new Vector3(0, 1 * iter, 0);
        }
    }
    void PauseButtonCallback()
    {
        pause = !pause;
    }

    void ScreenshotButtonCallback()
    {
        string fileName = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "");

        if (fileName.Length != 0)
        {
            UnityEngine.ScreenCapture.CaptureScreenshot(fileName);
        }
    }
}
