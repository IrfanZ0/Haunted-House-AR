using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IYellowDiamondReader
{
    bool YellowDiamondScanning ( GameObject yellowDiamond );

    void YellowDiamondTriggering ( GameObject yellowDiamond );

    bool YellowDiamondDestroying ( GameObject yellowDiamond );
}