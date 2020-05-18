using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory
{
    private object value;

    public Memory(object value)
    {
        this.value = value;
    }

    public object GetValue()
    {
        return value;
    }

    public void SetValue(object newValue)
    {
        value = newValue;
    }
}


public class Blackboard : MonoBehaviour
{
    Dictionary<string, Memory> memorias = new Dictionary<string, Memory>();

    public Dictionary<string, Memory> MemoriasAccesibles { get => memorias; set => memorias = value; }

    public object Get(string memoryName)
    {
        return memorias.ContainsKey(memoryName) ? memorias[memoryName].GetValue() : null;
    }

    public void Set(string memoryName, object memoryValue)
    {
        if (memorias.ContainsKey(memoryName))
        {
            memorias[memoryName].SetValue(memoryValue);
        }
        else
        {
            var newMemory = new Memory(memoryValue);
            memorias.Add(memoryName, newMemory);
        }
    }
}