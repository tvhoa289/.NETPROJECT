using Umbraco.Core.Migrations.Expressions.Common;

namespace Umbraco.Core.Migrations.Expressions.Create.Column
{
    public interface ICreateColumnOptionBuilder : IColumnOptionBuilder<ICreateColumnOptionBuilder, ICreateColumnOptionForeignKeyCascadeBuilder>
        , IExecutableBuilder
    { }
}
