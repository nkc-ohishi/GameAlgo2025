using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR;

public class DisableCloseButton : MonoBehaviour
{
    const int MF_BYCOMMAND = 0x00000000;
    const int SC_CLOSE = 0xF060;

    [DllImport("user32.dll")]
    static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    [DllImport("user32.dll")]
    static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();

    void Start()
    {
#if UNITY_STANDALONE_WIN
        IntPtr windowHandle = GetActiveWindow();
        IntPtr hMenu = GetSystemMenu(windowHandle, false);
        DeleteMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);

#endif
    }
}