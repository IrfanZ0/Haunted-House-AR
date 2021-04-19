using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPurpleDiamondReader
{
    bool PurpleDiamondScanning ( GameObject purpleDiamond );

    void PurpleDiamondTriggering ( GameObject purpleDiamond );

    bool PurpleDiamondDestroying ( GameObject purpleDiamond );
}