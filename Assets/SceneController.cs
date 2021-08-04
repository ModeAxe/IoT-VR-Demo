using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vuplex.WebView;
using System;
using System.Timers;

public class SceneController : MonoBehaviour
{
    public GameObject lightSwitch;
    public GameObject mainLight;
    private Timer _buttonRefreshTimer = new Timer();
    public WebViewPrefab _mainWebViewPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnWebView();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.vKey.wasPressedThisFrame)
        {
            mainLight.SetActive(mainLight.activeInHierarchy ? false : true);
            _mainWebViewPrefab.WebView.ExecuteJavaScript("document.write('LIGHT SWITCH')");

        }

    }

    void spawnWebView()
    {
        Debug.Log("Hello Are You There?");
        _mainWebViewPrefab = WebViewPrefab.Instantiate(0.6f, 0.3f);
        _mainWebViewPrefab.transform.parent = transform;
        _mainWebViewPrefab.transform.localPosition = new Vector3(2.9f, 3f, 0.4f);
        _mainWebViewPrefab.transform.localEulerAngles = new Vector3(0, 180, 0);
        _mainWebViewPrefab.Initialized += (initializedSender, initializedEventArgs) => {
            //_mainWebViewPrefab.WebView.UrlChanged += MainWebView_UrlChanged;
            _mainWebViewPrefab.WebView.LoadUrl("https://www.blender.org");
        };

    }
    void MainWebView_UrlChanged(object sender, UrlChangedEventArgs eventArgs)
    {

        _setDisplayedUrl(eventArgs.Url);
        _buttonRefreshTimer.Start();
    }
    void _setDisplayedUrl(string url)
    {

    }
}
