using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonTest = root.Q<Button>("TestButton");

        buttonTest.clicked += () => SceneManager.LoadScene("Intro Cutscene");
    }
}
