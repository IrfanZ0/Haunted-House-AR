using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IYellowDiamond
{
    void YellowDiamondScanning ( GameObject yellowDiamond );

    void YellowDiamondTriggering ( GameObject yellowDiamond );

    void YellowDiamondDestroying ( GameObject yellowDiamond );
}