using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginTester : MonoBehaviour
{

    public GameObject cube;

    const string DLL_NAME = "GameEngineInClass2";

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    struct Vector3D
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Runtime.InteropServices.DllImport(DLL_NAME)]
    private static extern int GetID();

    [System.Runtime.InteropServices.DllImport(DLL_NAME)]
    private static extern void SetID(int id);
    
    [System.Runtime.InteropServices.DllImport(DLL_NAME)]
    private static extern Vector3D GetPosition();

    [System.Runtime.InteropServices.DllImport(DLL_NAME)]
    private static extern void SetPosition(float x, float y, float z);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetID(12);

            Debug.Log(GetID());

            SetPosition(1.91f, 1.4201f, 9.2f);
            cube.transform.position = new Vector3(GetPosition().x, GetPosition().y, GetPosition().z);
            Debug.Log(GetPosition().x);
            Debug.Log(GetPosition().y);
            Debug.Log(GetPosition().z);
        }
    }
}
