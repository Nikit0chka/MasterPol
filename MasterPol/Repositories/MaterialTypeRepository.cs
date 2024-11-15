using MasterPol.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.Repositories;

public class MaterialTypeRepository(DbContext context):Repository<MaterialType>(context);