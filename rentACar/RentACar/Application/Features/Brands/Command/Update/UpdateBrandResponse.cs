﻿namespace Application.Features.Brands.Command.Update
{
    public class UpdateBrandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
     
    }
}
