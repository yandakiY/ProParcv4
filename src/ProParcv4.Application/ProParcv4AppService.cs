using ProParcv4.Localization;
using Volo.Abp.Application.Services;

namespace ProParcv4;

/* Inherit your application services from this class.
 */
public abstract class ProParcv4AppService : ApplicationService
{
    protected ProParcv4AppService()
    {
        LocalizationResource = typeof(ProParcv4Resource);
    }
}
