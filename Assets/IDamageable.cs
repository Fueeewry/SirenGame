using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void damaged(int damage);
    void reducedby();
    void restorespeed();
    void vulnerable(float increase);
    void restorevulnerable();
}
