using ProParcv4.Samples;
using Xunit;

namespace ProParcv4.EntityFrameworkCore.Domains;

[Collection(ProParcv4TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProParcv4EntityFrameworkCoreTestModule>
{

}
