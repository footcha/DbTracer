using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public abstract class CodeGeneratorBaseTest<TGenerator, T> : GeneratorBaseTest<TGenerator, T>
        where T : ICode
        where TGenerator : IGenerator<T>
    {}
}