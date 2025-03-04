using System;

namespace Vakili.StoreTest.Products
{
    public class CreateUpdateProductDto
    {
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
    }
}
