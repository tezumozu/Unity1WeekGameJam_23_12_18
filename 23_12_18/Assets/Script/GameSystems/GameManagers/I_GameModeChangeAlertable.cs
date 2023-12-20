using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_GameModeChangeAlertable {
   public abstract void ObserveGameModeChange(Action<E_GameMode> action);
}
