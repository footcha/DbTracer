using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class FunctionMap : SubclassMap<Function>
    {
        protected FunctionMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.SqlScalarFunction));
            SqlClassMap<SqlObject>.ConfigureCode(this);
        }
    }
}