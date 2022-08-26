﻿using Application.Common.CommenModel;
using Application.Common.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappers
{
    public class ServiceResponseMapper : IMapper<Object, ServiceResponse>
    {

        public ServiceResponse Map(object input)
        {
            return new ServiceResponse
            {
                ReturnObject = input,
                IsError = false
            };
        }
    }
}