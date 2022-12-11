using ConversionService.Core.Entities;
using ConversionService.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ConversionService.Core.Repository.Impl
{
    public class ConversionUnitsRepository : IConversionUnitsRepository
    {

        private readonly DataContext _dataContext;
        public ConversionUnitsRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<bool> DeactivateConversionUnit(ConversionUnit conversionUnit)
        {
            conversionUnit.IsActive = false;
            _dataContext.ConversionUnits.Update(conversionUnit);
            return await SaveChanges();
        }


        public async Task<IEnumerable<ConversionUnit>> FindAllConversionUnits()
        {
            return await _dataContext.ConversionUnits
               .Where(unit => unit.IsActive == true)
               .OrderBy(unit => unit.CreatedAt)
               .ToListAsync();
        }

        public async Task<ConversionUnit> FindConversionUnitById(long Id)
        {

            var conversionUnit = await _dataContext.ConversionUnits
                .Where(unit => unit.IsActive == true && unit.Id == Id)
                .FirstOrDefaultAsync();

            if (conversionUnit == null)
            {
                return null;
            }

            return conversionUnit;

        }


        public async Task<ConversionUnit> SaveConversionUnit(ConversionUnit conversionUnit)
        {
            var savedConversionUnit = await _dataContext.ConversionUnits.AddAsync(conversionUnit);
            if (await SaveChanges())
            {
                return savedConversionUnit.Entity;
            }
            return null;
        }


        public async Task<ConversionUnit> UpdateActivity(ConversionUnit conversionUnit)
        {
            var updatedConversion = _dataContext.ConversionUnits.Update(conversionUnit);
            if (await SaveChanges())
            {
                return updatedConversion.Entity;
            }
            return null;
        }


        private async Task<bool> SaveChanges()
        {
            try
            {
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
