using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DataPersistence
{
    void LoadGame(GameData data);
    void SaveGame(ref GameData data);
}
