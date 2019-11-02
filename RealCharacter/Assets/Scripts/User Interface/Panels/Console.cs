using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    [SerializeField] private Text logTextField;

    private Animator animator;

    private bool isOpen = false;

    private string currentLog = "";

    private static int scrollbackLimit = 20;

    private static Queue<string> scrollback = new Queue<string>();

    private static string[] log = new string[20];

    private static Action<string[]> OnLogUpdated;

    private void Start()
    {
        animator = GetComponent<Animator>();

        logTextField.text = "";
    }

    private void OnEnable()
    {
        OnLogUpdated += UpdateTextField;
    }

    private void OnDisable()
    {
        OnLogUpdated -= UpdateTextField;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);
        }
    }

    public static void UpdateLog(string message)
    {
        Debug.Log(message);

        if (scrollback.Count >= scrollbackLimit)
        {
            scrollback.Dequeue();
        }
        scrollback.Enqueue(message);

        log = scrollback.ToArray();

        if (log != null && OnLogUpdated != null)
        {
            OnLogUpdated(log);
        }
    }

    private void UpdateTextField(string[] logText)
    {
        logTextField.text = String.Join("\n", logText);
    }
}
