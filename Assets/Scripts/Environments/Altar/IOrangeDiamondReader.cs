using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrangeDiamondReader
{

    bool OrangeDiamondScanning ( GameObject orangeDiamond );

    void OrangeDiamondTriggering ( GameObject orangeDiamond );

    bool OrangeDiamondDestroying ( GameObject orangeDiamond );
}