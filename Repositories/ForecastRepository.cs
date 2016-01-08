using Forecast.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Domain.Repositories
{
    public class ForecastRepository : ForecastRepositoryBase
    {
        private readonly IndividualAssignmentEntities _context = new IndividualAssignmentEntities();

        public override void AddForecast(Forecast forecast)
        {
            _context.Forecasts.Add(forecast);
        }

        public override void DeleteForecast(int id)
        {
            var forecast = _context.Forecasts.Find(id);
            _context.Forecasts.Remove(forecast);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

        public override void UpdateForecast(Forecast forecast)
        {
            _context.Entry(forecast).State = EntityState.Modified;
        }

        protected override IQueryable<Forecast> QueryForecasts()
        {
            return _context.Forecasts;
        }
    }
}
