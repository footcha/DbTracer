using System;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class CheckConstraintGenerator : CodeGeneratorBase<CheckConstraint>
    {
        public CheckConstraintGenerator(CheckConstraint sourceObject)
            : base(sourceObject) { }

        public override string ObjectNameKeyWord
        {
            get { throw new NotImplementedException(); }
        }
    }
}