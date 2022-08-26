﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfases
{
    public interface IMapper<in TInput, out TOutput>
    {
        TOutput Map(TInput input);
    }
}
