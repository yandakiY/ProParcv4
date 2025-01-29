using Xunit;

namespace ProParcv4.EntityFrameworkCore;

[CollectionDefinition(ProParcv4TestConsts.CollectionDefinitionName)]
public class ProParcv4EntityFrameworkCoreCollection : ICollectionFixture<ProParcv4EntityFrameworkCoreFixture>
{

}
