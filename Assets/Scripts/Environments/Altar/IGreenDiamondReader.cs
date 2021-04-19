using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGreenDiamondReader
{
    bool GreenDiamondScanning ( GameObject greenDiamond );

    void GreenDiamondTriggering ( GameObject greenDiamond );

    bool GreenDiamondDestroying ( GameObject greenDiamond );
}