using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_InputUpdatable {
    public abstract void UpdateInput();
    public abstract InputData[] GetInputList();
    public abstract InputData[] GetInputBuffer();
}
