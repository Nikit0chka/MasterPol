using MasterPol.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.Repositories;

public class ProductTypesRepository(DbContext context):Repository<ProductType>(context);