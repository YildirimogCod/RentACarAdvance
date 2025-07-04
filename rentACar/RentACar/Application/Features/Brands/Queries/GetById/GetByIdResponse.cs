﻿namespace Application.Features.Brands.Queries.GetById
{
    public class GetByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
