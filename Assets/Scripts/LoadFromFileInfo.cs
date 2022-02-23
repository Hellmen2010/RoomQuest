using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum loadingType
{
    None, NewGame, FromFile
}

public static class LoadFromFileInfo
{
    public static loadingType loadFromFileState = loadingType.None;
}
