using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        // 属性的名称为数据库的表名，DbSet结果的类型参数为模型类型
        //此例中，属性名是Produces（数据库中的表名），参数类型是Product（用来表示该表中一行数据的模型类（Product类）的类型（Product））
        public DbSet<Product> Products { get; set; }
    }
}
