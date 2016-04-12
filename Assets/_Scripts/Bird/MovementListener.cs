using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using UnityEngine.EventSystems;

namespace Assets._Scripts
{
    public interface MovementListener
    {

        void OnMove(MovementDirection md, int value);

    }
}
