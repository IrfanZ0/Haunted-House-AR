using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPurpleDiamond
{
    void PurpleDiamondScanning ( GameObject purpleDiamond );

    void PurpleDiamondTriggering ( GameObject purpleDiamond );

    void PurpleDiamondDestroying ( GameObject purpleDiamond );
}