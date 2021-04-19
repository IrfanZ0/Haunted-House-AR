using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRedDiamondReader
{
    bool RedDiamondScanning ( GameObject redDiamond );

    void RedDiamondTriggering ( GameObject redDiamond );

    bool RedDiamondDestroying ( GameObject redDiamond );
}