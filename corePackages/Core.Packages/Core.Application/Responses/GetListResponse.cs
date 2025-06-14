﻿using Core.Persistence.Paging;

namespace Core.Application.Responses
{
    public class GetListResponse<T>:BasePageableModel
    {
        private IList<T> _items;

        public IList<T> items
        {
            get => _items ??= new List<T>();
            set => _items = value;
        }
    }
}
