using System;
using DbTracer.Core.Schema.Model;
using DbTracer.Core.Schema.SqlGenerator;
using MbUnit.Framework;
using Rhino.Mocks;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class GeneratorBaseTest<TGenerator, T>
        where TGenerator : IGenerator<T>
    {
        protected MockRepository Mocks;
        protected T TestedObject;
        protected TGenerator TestedGenerator;
        protected IKeywordEncoder KeyWordEncoder;
        protected IFullNameBuilder FullNameBuilder;

        [SetUp]
        public virtual void SetUp()
        {
            Mocks = new MockRepository();
            using (Mocks.Record())
            {
                KeyWordEncoder = GetDefaultKeyWordEncoderMock();
                FullNameBuilder = GetDefaultFullNameBuilderMock();
            }
        }

        protected virtual IFullNameBuilder GetDefaultFullNameBuilderMock()
        {
            var builder = Mocks.DynamicMock<IFullNameBuilder>();
            SetupResult.For(builder.BuildName(null))
                .IgnoreArguments()
                .Do(new Func<ISqlObject, string>(obj => String.Format("[{0}]", obj.Name)));

            return builder;
        }

        protected virtual IKeywordEncoder GetDefaultKeyWordEncoderMock()
        {
            var keyWordEncoder = Mocks.DynamicMock<IKeywordEncoder>();
            SetupResult.For(keyWordEncoder.Encode(null))
                .IgnoreArguments()
                .Do(new Func<string, string>(text => String.Format("[{0}]", text)));

            return keyWordEncoder;
        }

        protected TGenerator BuildGenerator(TGenerator generator)
        {
            return (TGenerator)new GeneratorBuilder()
                                    .WithFullNameBuilder(FullNameBuilder)
                                    .WithKeyWordEncoder(KeyWordEncoder)
                                    .Build(generator);
        }
    }

    public class GeneratorBuilder
    {
        private IFullNameBuilder fullnameBuilder;
        private IKeywordEncoder keyWordEncoder;

        public GeneratorBuilder WithFullNameBuilder(IFullNameBuilder builder)
        {
            fullnameBuilder = builder;
            return this;
        }

        public GeneratorBuilder WithKeyWordEncoder(IKeywordEncoder encoder)
        {
            keyWordEncoder = encoder;
            return this;
        }

        public IGenerator<T> Build<T>(IGenerator<T> generator)
        {
            generator.FullNameBuilder = fullnameBuilder;
            generator.KeywordEncoder = keyWordEncoder;

            return generator;
        }
    }
}