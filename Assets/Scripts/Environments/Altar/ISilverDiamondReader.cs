using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISilverDiamondReader
{
    bool SilverDiamondScanning ( GameObject silverDiamond );

    void SilverDiamondTriggering ( GameObject silverDiamond );

    bool SilverDiamondDestroying ( GameObject silverDiamond );
}