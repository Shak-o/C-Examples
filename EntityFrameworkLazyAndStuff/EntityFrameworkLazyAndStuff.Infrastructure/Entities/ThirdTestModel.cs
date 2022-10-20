using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkLazyAndStuff.Infrastructure.Entities
{
    public class ThirdTestModel
    {
        private ILazyLoader LazyLoader { get; set; }
        private MaTestModel? _maTestModel;

        public int Id { get; set; }
        public string Name { get; set; }

        
        public ThirdTestModel(ILazyLoader loader)
        {
            LazyLoader = loader;
        }
        public MaTestModel? MaTestModel
        {
            get => LazyLoader.Load(this, ref _maTestModel);
            set => _maTestModel = value;
        }

    }
}
