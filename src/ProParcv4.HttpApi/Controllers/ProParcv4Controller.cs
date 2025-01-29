using ProParcv4.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ProParcv4.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProParcv4Controller : AbpControllerBase
{
    protected ProParcv4Controller()
    {
        LocalizationResource = typeof(ProParcv4Resource);
    }
}
