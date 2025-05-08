using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class RemoveCloseButton : MonoBehaviour
{
    const int GWL_STYLE = -16;
    const uint WS_SYSMENU = 0x00080000;

    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    void Start()
    {
#if UNITY_STANDALONE_WIN
        IntPtr hWnd = GetActiveWindow();
        uint style = GetWindowLong(hWnd, GWL_STYLE);
        SetWindowLong(hWnd, GWL_STYLE, style & ~WS_SYSMENU);  // ✕含むシステムメニューを除去
#endif
    }
}