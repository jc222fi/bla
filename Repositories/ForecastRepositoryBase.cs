using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Domain.Repositories
{
    public abstract class ForecastRepositoryBase: IForecastRepository
    {
        protected abstract IQueryable<Forecast> QueryForecasts();

        public abstract void AddForecast(Forecast forecast);

        public abstract void DeleteForecast(int id);

        public Forecast GetForecast(int id)
        {
            return QueryForecasts().SingleOrDefault(t => t.ForecastId == id);
        }

        public IEnumerable<Forecast> GetForecasts()
        {
            return QueryForecasts().ToList();
        }

        public IEnumerable<Forecast> GetForecastsByLocation(Location location)
        {
            List<Forecast> forecasts = new List<Forecast>();
            var collection = QueryForecasts().ToLookup(f => f.location == location.Name).AsEnumerable();
            foreach(var coll in collection)
            {
                foreach (var item in coll)
                {
                    forecasts.Add(item); 
                }
            }
            return forecasts;
        }
        public abstract void UpdateForecast(Forecast forecast);
        
        protected virtual void Dispose(bool disposing)
        {
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract void Save();

    }
}
