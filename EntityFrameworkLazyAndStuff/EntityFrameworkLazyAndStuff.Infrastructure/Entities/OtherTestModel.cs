namespace EntityFrameworkLazyAndStuff.Infrastructure.Entities
{
    public class OtherTestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaTetModelId { get; set; }
        public virtual MaTestModel MaTest { get; set; }

    }
}
