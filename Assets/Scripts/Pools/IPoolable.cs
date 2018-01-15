using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable<T> {

    void SetVisibility(bool visible);

    void TransferPoolObjects(T pool);

    void ClearPool();

}
