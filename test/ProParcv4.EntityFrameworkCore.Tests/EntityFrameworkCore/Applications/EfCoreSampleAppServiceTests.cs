using ProParcv4.Samples;
using Xunit;

namespace ProParcv4.EntityFrameworkCore.Applications;

[Collection(ProParcv4TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProParcv4EntityFrameworkCoreTestModule>
{

}
