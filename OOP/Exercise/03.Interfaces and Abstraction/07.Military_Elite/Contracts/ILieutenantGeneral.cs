﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}
