using ProParcv4.Books;
using Xunit;

namespace ProParcv4.EntityFrameworkCore.Applications.Books;

[Collection(ProParcv4TestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<ProParcv4EntityFrameworkCoreTestModule>
{

}