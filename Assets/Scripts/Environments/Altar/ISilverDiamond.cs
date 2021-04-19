using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISilverDiamond
{
    void SilverDiamondScanning ( GameObject silverDiamond );

    void SilverDiamondTriggering ( GameObject silverDiamond );

    void SilverDiamondDestroying ( GameObject silverDiamond );
}