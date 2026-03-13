using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class GateInfo : MonoBehaviour
{
    public int value;
    public string op; 
    private TextMeshPro textMesh;
    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
        if (textMesh != null)
        {
            textMesh.text = $"{op} {value}";
        }
    }
}
