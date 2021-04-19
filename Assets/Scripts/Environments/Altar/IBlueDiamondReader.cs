using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlueDiamondReader
{
    bool BlueDiamondScanning ( GameObject blueDiamond );

    void BlueDiamondTriggering ( GameObject blueDiamond );

    bool BlueDiamondDestroying ( GameObject blueDiamond );
}