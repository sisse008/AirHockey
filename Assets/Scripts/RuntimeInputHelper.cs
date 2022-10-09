using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeInputHelper : MonoBehaviour
{
    public class InputType
    {
        public enum InputTypeEnum
        {
            Arrows,
            ASWD,
            Both,
            None
        };

        InputTypeEnum type;
        public AxisInputAction action;
        string inputSystemNameHorizontal;
        string inputSystemNameVertical;
        public InputType(InputTypeEnum type, AxisInputAction action, string inputSystemNameHorizontal, string inputSystemNameVertical)
        {
            this.type = type;
            this.action = action;
            this.inputSystemNameHorizontal = inputSystemNameHorizontal;
            this.inputSystemNameVertical = inputSystemNameVertical;
        }
        public void ListerForInput()
        {
            float horizontal = Input.GetAxisRaw(inputSystemNameHorizontal);
            float vertical = Input.GetAxisRaw(inputSystemNameVertical);

            if (horizontal != 0 || vertical != 0)
            {
                action?.Invoke(horizontal, vertical);
            }
        }

        public void UnregisterEvents()
        {
            if (action == null)
                return;
            foreach (Delegate d in action.GetInvocationList())
            {
                action -= (AxisInputAction)d;
            }
        }
    }

    public delegate void AxisInputAction(float horizontal, float vertical);
    public static event AxisInputAction AxisInputPressed;
    public static event AxisInputAction AWSDInputPressed;
    public static event AxisInputAction ArrowsInputPressed;

    public static Dictionary<InputType.InputTypeEnum, InputType> inputTypeDictionary { get; private set; } =
        new Dictionary<InputType.InputTypeEnum, InputType>();

    private void Awake()
    {
        InputType awsd = new InputType(InputType.InputTypeEnum.ASWD, AWSDInputPressed,
            "HorizontalAWSD", "VerticalAWSD");

        InputType arrows = new InputType(InputType.InputTypeEnum.Arrows, ArrowsInputPressed,
            "HorizontalArrows", "VerticalArrows");

        InputType axis = new InputType(InputType.InputTypeEnum.Both, AxisInputPressed,
            "Horizontal", "Vertical");

        inputTypeDictionary[InputType.InputTypeEnum.ASWD] = awsd;
        inputTypeDictionary[InputType.InputTypeEnum.Arrows] = arrows;
        inputTypeDictionary[InputType.InputTypeEnum.Both] = axis;
    }

    public static void RegisterInputEvents(InputType.InputTypeEnum inputTypeEnum,Action<float, float> onEvent)
    {
        if (inputTypeEnum == InputType.InputTypeEnum.None)
            return;
        inputTypeDictionary[inputTypeEnum].action += (float x, float y) => onEvent?.Invoke(x,y) ;
    }

    private void OnDisable()
    {
        foreach (InputType inputType in inputTypeDictionary.Values)
            inputType.UnregisterEvents();
    }

    public static bool ShiftKeyDown()
    {
         return Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
    }
    public static bool ShiftKeyHold()
    {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }
    public static bool NumberKeyDown(int num)
    {
        switch (num)
        {
            case 0:
                return Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0);
            case 1:
                return Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1);
            case 2:
                return Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2);
            case 3:
                return Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3);
            case 4:
                return Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4);
            case 5:
                return Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5);
            case 6:
                return Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6);
            case 7:
                return Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7);
            case 8:
                return Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8);
            case 9:
                return Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9);
        }
        return false;
    }


    private void FixedUpdate()
    {
        foreach (InputType inputType in inputTypeDictionary.Values)
            inputType.ListerForInput();
    }
}
