﻿using System.ComponentModel.DataAnnotations;

namespace DemoMS.Service.DTOS
{
    public record UpdateItemDTO(string Name, string Description, decimal Price);
}
