﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactingForTesting
{
    public interface ILerArquivo:IDisposable
    {
        string ReadLine();
    }
}
