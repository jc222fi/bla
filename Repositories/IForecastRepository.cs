using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Domain.Repositories
{
    public interface IForecastRepository: IDisposable
    {
        IEnumerable<Forecast> GetForecasts();
        IEnumerable<Forecast> GetForecastsByLocation(Location location);
        Forecast GetForecast(int id);
        void AddForecast(Forecast forecast);
        void UpdateForecast(Forecast forecast);
        void DeleteForecast(int id);
        void Save();
    }
}
