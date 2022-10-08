#if  UNITY_EDITOR


using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Linq;

[InitializeOnLoad]
public class EditorInputListener
{

    public static bool isShiftKeyHold { get; private set; }

    //if no number is pressed, set to -1
    public static int currentNumberPressed { get; private set; } = -1;

    public delegate void InputActionInEditMode(Event e);
    public static event InputActionInEditMode OnKeyDown;
    public static event InputActionInEditMode OnKeyUp;

    public delegate void ShiftKeyActionInEditMode();
    public static event ShiftKeyActionInEditMode OnNumPressedWhileShiftDown;

    static void SetUpEvents()
    {
        OnKeyUp += CheckShiftKeyEvent;
        OnKeyDown += CheckShiftKeyEvent;
        OnKeyDown += (e) => {
            bool isNumberKey = EditorInputHelperFunctions.GetNumberCurrentlyPressed(e) != -1;
            if (isNumberKey)
            {
                currentNumberPressed = EditorInputHelperFunctions.GetNumberCurrentlyPressed(e);
                if (isShiftKeyHold)
                    OnNumPressedWhileShiftDown?.Invoke();
            }
        };

        OnKeyUp += (e) => { currentNumberPressed = -1; };
    }

    static EditorInputListener()
    {
        SetUpEvents();
    }
    

    static bool firstFrameOfKeyDown = true;
    static void OnSceneGUI()
    {
       
       Event e = Event.current;
        if (e != null)
        {
            Debug.Log("e.type = " + e.type);
            Debug.Log("e.keyCode" + e.keyCode);
            // Debug.Log("e.type = " + e.type);
            if (e.type == EventType.KeyDown)
            {
                if (firstFrameOfKeyDown)
                {
                    OnKeyDown?.Invoke(e);
                    Debug.Log("222222222222");
                    firstFrameOfKeyDown = false;
                }
               
            }
            if (e.type == EventType.KeyUp)
            {
                Debug.Log("333333333333");
                OnKeyUp?.Invoke(e);
                firstFrameOfKeyDown = true;
            }
        }
    }

    public static void CheckShiftKeyEvent(Event e)
    {
        if (e == null)
            return;
        if (e.type == EventType.KeyDown)
        {
            if (EditorInputHelperFunctions.ShiftKeyCode(e))
                isShiftKeyHold = true;
        }
        if (e.type == EventType.KeyUp)
        {
            if (EditorInputHelperFunctions.ShiftKeyCode(e))
                isShiftKeyHold = false;
        }
    }
}

#endif
