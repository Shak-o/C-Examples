using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;

namespace CustomModelBinder.Infrastructure
{
    public class MyModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext is null)
                throw new ArgumentNullException(nameof(bindingContext));

            var now = DateTime.Now;
            var type = bindingContext.ModelType;
            var properties = type.GetProperties();
            var assembly = type.Assembly;
            var toReturn = assembly.CreateInstance(type.FullName);

            if (type.BaseType == typeof(BaseModel))
            {
                for (var i = 0; i < properties.Length; i++)
                {
                    var prop = properties[i];
                   
                    if (prop.PropertyType.Name == "DateTime" && prop.Name == "CreateDate")
                    {
                        prop.SetValue(toReturn, now);
                    }
                    else
                    {
                        var data = Convert.ChangeType(bindingContext.ValueProvider.GetValue(prop.Name).FirstValue,
                            prop.PropertyType);
                        prop.SetValue(toReturn, data);
                    }
                }
            }

            bindingContext.Result = ModelBindingResult.Success(toReturn);

            return Task.CompletedTask;
        }
    }
}
