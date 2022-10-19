using CustomModelBinder.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelBinder.Models
{
    [ModelBinder(BinderType = typeof(MyModelBinder))]
    public class FooModel : BaseModel
    {
        public string? Name { get; set; }
    }
}
